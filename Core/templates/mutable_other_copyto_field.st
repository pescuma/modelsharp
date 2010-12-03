$if(it.LazyInitializer)$
			if (other.$it.FieldName$ != null) 
			{
$endif$
$if(it.IsCollection)$
				$it.Name$.Clear();
				$it.Name$.AddRange(other.$it.Name$);
$elseif(it.IsComponent)$
				$it.Name$.CopyFrom(other.$it.Name$);
$else$
				$it.Name$ = other.$it.Name$;
$endif$
$if(it.LazyInitializer)$
			}
			else
			{
$if(it.IsCollection)$
				if ($it.FieldName$ != null)
					$it.Name$.Clear();
$elseif(it.IsComponent)$
				if ($it.FieldName$ != null)
					$it.FieldName$.CopyFrom(new $it.TypeName$());
$endif$
			}
$endif$