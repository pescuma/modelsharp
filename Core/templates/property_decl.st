$it.Annotations:annotation()$
public $it.TypeName$ $it.Name$ 
{
	$if(it.Getter)$$if(it.PropGetAnnotations)$$it.PropGetAnnotations:annotation()$$\n$$endif$$if(it.GetterVisibility)$$it.GetterVisibility$ $endif$get{ return $it.Getter:call()$ }$endif$
	$if(it.Setter)$$if(it.PropSetAnnotations)$$it.PropSetAnnotations:annotation()$$\n$$endif$$if(it.SetterVisibility)$$it.SetterVisibility$ $endif$set{ $it.Setter.Name$(value); }$endif$
}
