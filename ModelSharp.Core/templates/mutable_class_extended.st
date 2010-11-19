$it.Using:create_using()$

$if(it.Package)$
namespace $it.Package$
{
$endif$

	$it.Annotations:annotation()$
	public class $it.Name$ : $it.ImplementationName$
	{
		public $it.Name$()
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
