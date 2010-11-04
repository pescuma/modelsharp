$it.Annotations:annotation()$
public $it.TypeName$ $it.Name$ 
{
	$if(it.Getter)$$if(it.PropGetAnnotations)$$it.PropGetAnnotations:annotation()$$\n$$endif$get{ return $it.Getter:call()$ }$endif$
	$if(it.Setter)$$if(it.PropSetAnnotations)$$it.PropSetAnnotations:annotation()$$\n$$endif$set{ $it.Setter.Name$(value); }$endif$
}
