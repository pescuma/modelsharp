namespace $it.Package$
{
	public class $class$
	{
		$it.Fields:builder_field()$

		$it.Fields:builder_setter()$

		public $it.Name$ Build()
		{
			return new $it.Name$($it.Fields:private_name(); separator=", "$);
		}
	}
}