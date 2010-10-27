$if(it.LazyInitializer)$
		$it.LazyInitializer.Annotations:annotation()$
		protected $it.LazyInitializer.TypeName$ $it.LazyInitializer.Name$() 
		{
			if ($it.Field.Name$ != null)
				return;

			$it.Field.Name$ = new $it.TypeName$();
		}

$endif$
$if(it.Getter)$
		$it.Getter.Annotations:annotation()$
		protected $it.Getter.TypeName$ $it.Getter.Name$()
		{
			$it.LazyInitializer:call()$
			return $it.Field.Name$;
		}

$endif$
$if(it.Setter)$
		$it.Setter.Annotations:annotation()$
		protected $it.Setter.TypeName$ $it.Setter.Name$($first(it.Setter.Parameters)$ value) 
		{
			if ($it.Field.Name$ == value)
				return;

			$it.Field.Name$ = value;

			OnPropertyChanged(PROPERTIES.$it.DefineName$);
		}

$endif$