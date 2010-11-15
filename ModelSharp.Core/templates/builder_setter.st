$if(it.IsCollection)$
		public virtual $class$ AddTo$it.Name$($it.Contents$ $it.VarName$) 
		{
			$it.PrivateName$.Add($it.VarName$);
			return this;
		}
		public virtual $class$ AddTo$it.Name$(IEnumerable<$it.Contents$> $it.VarName$) 
		{
			$it.PrivateName$.AddRange($it.VarName$);
			return this;
		}
$else$
		public virtual $class$ Set$it.Name$($it.TypeName$ $it.VarName$) 
		{
			$it.PrivateName$ = $it.VarName$;
			return this;
		}
$endif$