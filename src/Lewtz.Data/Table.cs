﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Lewtz.Data
{
	/// <summary>
	/// Holds a table of RDS objects. This class is "the randomizer" of the RDS.
	/// The Result implementation of the IRDSTable interface uses the RDSRandom class
	/// to determine which elements are hit.
	/// </summary>
	public class Table : Entity
	{
		#region CONSTRUCTORS
		/// <summary>
		/// Initializes a new instance of the <see cref="RDSTable"/> class.
		/// </summary>
		public Table()
			: this(null, 1, 1, false, false, true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RDSTable"/> class.
		/// </summary>
		/// <param name="contents">The contents.</param>
		/// <param name="count">The count.</param>
		/// <param name="probability">The probability.</param>
		public Table(IEnumerable<Entity> contents, int count, double probability)
			: this(contents, count, probability, false, false, true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RDSTable"/> class.
		/// </summary>
		/// <param name="contents">The contents.</param>
		/// <param name="count">The count.</param>
		/// <param name="probability">The probability.</param>
		/// <param name="unique">if set to <c>true</c> any item of this table (or contained sub tables) can be in the result only once.</param>
		/// <param name="always">if set to <c>true</c> the probability is disabled and the result will always contain (count) entries of this table.</param>
		/// <param name="enabled">if set to <c>true</c> [enabled].</param>
		public Table(IEnumerable<Entity> contents, int count, double probability, bool unique, bool always, bool enabled)
		{
			if (contents != null)
				mcontents = contents.ToList();
			else
				ClearContents();
			rdsCount = count;
			rdsProbability = probability;
			rdsUnique = unique;
			rdsAlways = always;
			rdsEnabled = enabled;
		}
		#endregion

		#region COUNT
		/// <summary>
		/// The maximum number of entries expected in the Result. The final count of items in the result may be lower
		/// if some of the entries may return a null result (no drop)
		/// </summary>
		public int rdsCount { get; set; }
		#endregion

		#region CONTENTS
		/// <summary>
		/// Gets or sets the contents of this table
		/// </summary>
		public IEnumerable<Entity> rdsContents
		{
			get { return mcontents; }
		}
		private List<Entity> mcontents = null;

		/// <summary>
		/// Clears the contents.
		/// </summary>
		public virtual void ClearContents()
		{
			mcontents = new List<Entity>();
		}

		/// <summary>
		/// Adds the given entry to contents collection.
		/// </summary>
		/// <param name="entry">The entry.</param>
		public virtual void AddEntry(Entity entry)
		{
			mcontents.Add(entry);
			entry.rdsTable = this;
		}

		/// <summary>
		/// Adds a new entry to the contents collection and allows directly assigning of a probability for it.
		/// Use this signature if (for whatever reason) the base classes constructor does not support all
		/// constructors of RDSObject or if you implemented Entity directly in your class and you need
		/// to (re)apply a new probability at the moment you add it to a RDSTable.
		/// NOTE: The probability given is written back to the given instance "entry".
		/// </summary>
		/// <param name="entry">The entry.</param>
		/// <param name="probability">The probability.</param>
		public virtual void AddEntry(Entity entry, double probability)
		{
			mcontents.Add(entry);
			entry.rdsProbability = probability;
			entry.rdsTable = this;
		}

		/// <summary>
		/// Adds a new entry to the contents collection and allows directly assigning of a probability and drop flags for it.
		/// Use this signature if (for whatever reason) the base classes constructor does not support all
		/// constructors of RDSObject or if you implemented Entity directly in your class and you need
		/// to (re)apply a new probability and flags at the moment you add it to a RDSTable.
		/// NOTE: The probability, unique, always and enabled flags given are written back to the given instance "entry".
		/// </summary>
		/// <param name="entry">The entry.</param>
		/// <param name="probability">The probability.</param>
		/// <param name="unique">if set to <c>true</c> this object can only occur once per result.</param>
		/// <param name="always">if set to <c>true</c> [always] this object will appear always in the result.</param>
		/// <param name="enabled">if set to <c>false</c> [enabled] this object will never be part of the result (even if it is set to always=true!).</param>
		public virtual void AddEntry(Entity entry, double probability, bool unique, bool always, bool enabled)
		{
			mcontents.Add(entry);
			entry.rdsProbability = probability;
			entry.rdsUnique = unique;
			entry.rdsAlways = always;
			entry.rdsEnabled = enabled;
			entry.rdsTable = this;
		}

        public int LoadFromFile(string path, string type, int p, string rank)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string str;
                while ((str = file.ReadLine()) != null)
                {
                    string[] strArray;
                    int cost = 0;
                    int prob = 0;
                    

                    strArray = str.Split(',');

                    string name = strArray[0];
                    switch (p)
                    {
                        case 1: //NORMAL
                            if(!int.TryParse(strArray[1], out cost)) //if this is an integer, output it as a cost
                            {
                                return 1;
                            }
                            if (!int.TryParse(strArray[2], out prob))
                            {
                                return 2;
                            }
                            break;

                        case 2: //GEMS
                            cost = 0;
                            if (!int.TryParse(strArray[1], out prob))
                            {
                                return 2;
                            }
                            break;

                        case 3://MAGIC WEAPONS
                            if (!int.TryParse(strArray[1], out cost)) //if this is an integer, output it as a cost
                            {
                                return 1;
                            }
                            switch(rank)
                            {
                                case "Minor": //Minor Items use the first column of probabilities
                                    if (!int.TryParse(strArray[2], out prob))
                                    {
                                        return 2;
                                    }
                                    break;
                                case "Medium"://Medium Items use the second column of probabilities
                                    if (!int.TryParse(strArray[3], out prob))
                                    {
                                        return 3;
                                    }
                                    break;
                                case "Major"://Major Items use the third column of probabilities
                                    if (!int.TryParse(strArray[4], out prob))
                                    {
                                        return 4;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            /*Do Nothing*/
                            break;

                    }
                    if (prob == 0)
                    {
                        continue; //skip this entry
                    }
                    else
                    {
                        mcontents.Add(new Item(type, name, cost, prob));
                    }
                }
                return 0; //everything is A-OK!
            }
        }


		/// <summary>
		/// Removes the given entry from the contents. If it is not part of the contents, an exception occurs.
		/// </summary>
		/// <param name="entry">The entry.</param>
		public virtual void RemoveEntry(Entity entry)
		{
			mcontents.Remove(entry);
			entry.rdsTable = null;
		}

		/// <summary>
		/// Removes the entry at the given index position.
		/// If the index is out-of-range of the current contents collection, an exception occurs.
		/// </summary>
		/// <param name="index">The index.</param>
		public virtual void RemoveEntry(int index)
		{
			Entity entry = mcontents[index];
			entry.rdsTable = null;
			mcontents.RemoveAt(index);
		}
		#endregion

		#region RESULT
		private List<Entity> uniquedrops = new List<Entity>();

		private void AddToResult(List<Entity> rv, Entity o)
		{
			if (!o.rdsUnique || !uniquedrops.Contains(o))
			{
				if (o.rdsUnique)
					uniquedrops.Add(o);

				// TODO: CS0184: https://msdn.microsoft.com/en-us/library/230kb9yt(v=vs.90).aspx
				if (!(o is NullValue))
				{
					if (o is Table)
					{
						rv.AddRange(((Table)o).rdsResult);
					}
					else
					{
						// INSTANCECHECK
						// Check if the object to add implements EntityCreator.
						// If it does, call the CreateInstance() method and add its return value
						// to the result set. If it does not, add the object o directly.
						Entity adder = o;
						if (o is CreatableEntity)
							adder = ((CreatableEntity)o).CreateInstance();

						rv.Add(adder);
						o.OnRDSHit(EventArgs.Empty);
					}
				}
				else
					o.OnRDSHit(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets the result. Calling this method will start the random pick process and generate the result.
		/// This result remains constant for the lifetime of this table object.
		/// Use the ResetResult method to clear the result and create a new one.
		/// </summary>
        /// 
        private List<int> rolledValues = new List<int>();
		public virtual IEnumerable<Entity> rdsResult
		{
			get
			{
				// The return value, a list of hit objects
				List<Entity> rv = new List<Entity>();
				uniquedrops = new List<Entity>();

				// Do the PreEvaluation on all objects contained in the current table
				// This is the moment where those objects might disable themselves.
				foreach (Entity o in mcontents)
					o.OnRDSPreResultEvaluation(EventArgs.Empty);

				// Add all the objects that are hit "Always" to the result
				// Those objects are really added always, no matter what "Count"
				// is set in the table! If there are 5 objects "always", those 5 will
				// drop, even if the count says only 3.
				foreach (Entity o in mcontents.Where(e => e.rdsAlways && e.rdsEnabled))
					AddToResult(rv, o);

				// Now calculate the real dropcount, this is the table's count minus the
				// number of Always-drops.
				// It is possible, that the remaining drops go below zero, in which case
				// no other objects will be added to the result here.
				int alwayscnt = mcontents.Count(e => e.rdsAlways && e.rdsEnabled);
				int realdropcnt = rdsCount - alwayscnt;

                

				// Continue only, if there is a Count left to be processed
				if (realdropcnt > 0)
				{
                    //List<int> rolledValues = new List<int>();
					for (int dropcount = 0; dropcount < realdropcnt; dropcount++)
					{
						// Find the objects, that can be hit now
						// This is all objects, that are Enabled and that have not already been added through the Always flag
						IEnumerable<Entity> dropables = mcontents.Where(e => e.rdsEnabled && !e.rdsAlways);

						// This is the magic random number that will decide, which object is hit now

						//double hitvalue = RDSRandom.GetDoubleValue(dropables.Sum(e => e.rdsProbability));
                        IEnumerable<int> dicevalue = Randomizer.RollDice(1,100);
                        
                        rolledValues.Add(dicevalue.ElementAt(0));
                        
						// Find out in a loop which object's probability hits the random value...
                        // For Dice Values, the dice must be between the low and high values, excluding the low and including the high
						//double runningvalue = 0;
                        double runValueLow = 0;
                        double runValueHigh = 0;
                        double previousProb = 0;
                        
						foreach (Entity o in dropables)
						{
							// Count up until we find the first item that exceeds the hitvalue...
							//runningvalue += o.rdsProbability;
                            
                            runValueLow = previousProb;
                            runValueHigh = o.rdsProbability;
                            //if(hitvalue < runningvalue) //normal function
							if (dicevalue.ElementAt(0) > runValueLow && dicevalue.ElementAt(0) <= runValueHigh) //dice function
							{
								// ...and the oscar goes too...
								AddToResult(rv, o);
								break;
							}
                            previousProb = o.rdsProbability;
						}
					}
				}

				// Now give all objects in the result set the chance to interact with
				// the other objects in the result set.
				ResultEventArgs rea = new ResultEventArgs(rv);
				foreach (Entity o in rv)
					o.OnRDSPostResultEvaluation(rea);

				// Return the set now
				return rv;
			}
		}
		#endregion

		#region TOSTRING
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return ToString(0);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <param name="indentationlevel">The indentationlevel. 4 blanks at the beginning of each line for each level.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString(int indentationlevel)
		{
			string indent = "".PadRight(4 * indentationlevel, ' ');

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(indent + "(RDSTable){0} Entries:{1}, Prob:{2}, UAE:{3}{4}{5}{6}", 
				this.GetType().Name, mcontents.Count, rdsProbability,
				(rdsUnique ? "1" : "0"), (rdsAlways ? "1" : "0"), (rdsEnabled ? "1" : "0"), (mcontents.Count > 0 ? "\r\n" : ""));

			foreach (Entity o in mcontents)
				sb.AppendLine(indent + o.ToString(indentationlevel + 1));

			return sb.ToString();
		}
		#endregion
        public int GetRolledValue(int i)
        {
            return rolledValues.ElementAt(i);
        }

        internal void ProbabilityMult(double multiplier)
        {
            var contents = from item in mcontents
                           select item;
            double[] previousProb = new double[contents.Count()+2];
            double probabilityDiff = 0;
            double finalProbDiff = 0;
            int iCount = 0;
            int n = 0; //iterator for foreach var
            double[] newProbability = new double[contents.Count()+2];
            string text = "";
            foreach (var item in contents) //does NOT include Item (nothing)
            {
                text += "n: " + n + "\r\n";
                if (n == 0)
                {
                    probabilityDiff = 0;
                    finalProbDiff = 0; //25 - 2 = 23 USED TO ADD TO "NOTHING"
                }
                else
                {
                    probabilityDiff = item.rdsProbability - (previousProb[n-1]); //75-25 //USED TO CALCULATE DIFFERENCE
                    newProbability[n-1] = Math.Truncate((probabilityDiff) * multiplier); //25 * 0.1 = 2 //USED TO CHANGE THE ROLLED VALUES (59-69 goes to 10*(mult))
                    finalProbDiff += probabilityDiff - newProbability[n-1]; //25 - 2 = 23 USED TO ADD TO NOTHING????
                    text += item.rdsProbability + " - " + previousProb[n - 1] + "\r\n----";
                }
                
                
                previousProb[n] = item.rdsProbability + newProbability[n];
                n++;
            }
            foreach (Entity m in mcontents)
            {
                iCount++;
                if(m.GetType().Name == "Item")
                {
                    previousProb[0] = (m.rdsProbability+finalProbDiff);
                    m.rdsProbability += finalProbDiff;
                }
                else
                {
                    if (iCount >= mcontents.Count())
                    {
                        m.rdsProbability = 100;
                    }
                    else
                    {
                        /*text += "\r\n---------------------------\r\n";
                        text += "------newprob[icount]------\r\n";
                        text += "----------" + previousProb[iCount - 1] + "-----------\r\n";
                        text += "----------" + newProbability[iCount] + "-----------\r\n";*/
                        m.rdsProbability = previousProb[iCount-1]+ newProbability[iCount-1];
                    }
                } 
            }
        }
    }
}