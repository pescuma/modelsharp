$it.Annotations:annotation()$
public $it.TypeName$ $it.Name$ 
{
	$if(it.Getter)$get{ return $it.Getter:call()$ }$endif$
	$if(it.Setter)$set{ $it.Setter.Name$(value); }$endif$
}
