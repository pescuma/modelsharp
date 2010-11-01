$if(it.LazyInitializer)$
		$it.LazyInitializer.Annotations:annotation()$
		protected virtual $it.LazyInitializer.TypeName$ $it.LazyInitializer.Name$() 
		{
			if ($it.Field.Name$ != null)
				return;

			$it.Field.Name$ = new $it.TypeName$();
		}

$endif$
$if(it.Getter)$
		$it.Getter.Annotations:annotation()$
		protected virtual $it.Getter.TypeName$ $it.Getter.Name$()
		{
			$it.LazyInitializer:call()$
			return $it.Field.Name$;
		}

$endif$
$if(it.Setter)$
		$it.Setter.Annotations:annotation()$
		protected virtual $it.Setter.TypeName$ $it.Setter.Name$($first(it.Setter.Parameters)$ value) 
		{
			if ($it.Field.Name$ == value)
				return;

			OnPropertyChanging(PROPERTIES.$it.DefineName$);

			$it.Field.Name$ = value;

			OnPropertyChanged(PROPERTIES.$it.DefineName$);
		}

$endif$