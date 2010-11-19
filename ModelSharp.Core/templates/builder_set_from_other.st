$if(it.IsCollection)$
	Clear$it.Name$();
	AddTo$it.Name$(other.$it.Name$);
$else$
	Set$it.Name$(other.$it.Name$);
$endif$
$\n$