$if(it.IsCollection)$
IEnumerable<$it.Contents$> $it.VarName$
$else$
$it.TypeName$ $it.VarName$
$endif$