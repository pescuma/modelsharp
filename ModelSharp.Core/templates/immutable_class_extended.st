$it.Using:create_using()$

namespace $it.Package$
{
	$it.Annotations:annotation()$
	public class $it.Name$ : $it.ImplementationName$
	{
		public $it.Name$($it.Properties:param(); separator=", "$)
			: base($it.Properties:var_name(); separator=", "$)
		{
		}

		public $it.Name$($it.Name$ other)
			: base(other)
		{
		}
	}
}
