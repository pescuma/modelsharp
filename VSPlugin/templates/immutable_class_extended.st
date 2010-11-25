$it.Using:create_using()$

$if(it.Package)$
namespace $it.Package$
{
$endif$

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

$if(it.Package)$
}
$endif$
