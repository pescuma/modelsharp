$if(it.LazyInitializer)$
		$it.LazyInitializer.Annotations:annotation()$
		protected virtual $it.LazyInitializer.TypeName$ $it.LazyInitializer.Name$() 
		{
			if ($it.FieldName$ != null)
				return;

$if(it.DefaultValue)$
			$it.FieldName$ = $it.DefaultValue$;
$else$
			$it.FieldName$ = new $it.TypeName$();
$endif$
		}

$endif$
$if(it.Getter)$
		$it.Getter.Annotations:annotation()$
		protected virtual $it.Getter.TypeName$ $it.Getter.Name$()
		{
			$it.LazyInitializer:call()$
			return $it.FieldName$;
		}

$endif$
$if(it.Setter)$
		$it.Setter.Annotations:annotation()$
		protected virtual $it.Setter.TypeName$ $it.Setter.Name$($first(it.Setter.Parameters)$ $it.VarName$) 
		{
			if ($it.FieldName$ == $it.VarName$)
				return;

			OnPropertyChanging(PROPERTIES.$it.DefineName$);

			$it.FieldName$ = $it.VarName$;

			OnPropertyChanged(PROPERTIES.$it.DefineName$);
		}

$endif$