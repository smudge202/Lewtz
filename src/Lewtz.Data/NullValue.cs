namespace Lewtz.Data
{
	/// <summary>
	/// This is the default class for a "null" entry in an RDSTable.
	/// It just contains a value that is null (if added to a table of RDSValue objects),
	/// but is a class as well and can be checked via a "if (obj is RDSNullValue)..." construct
	/// </summary>
	public class NullValue : Value<object>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NullValue"/> class.
		/// </summary>
		/// <param name="probability">The probability.</param>
		public NullValue(double probability)
			: base(null, probability, false, false, true) { }
	}
}
