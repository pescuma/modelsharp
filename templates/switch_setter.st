$if(it.Setter)$
				case $it.DefineName$:
					if (!(value is $it.TypeName$))
						throw new ArgumentException(fieldName + " must be of type $it.TypeName$");
					$it.Setter.Name$(($it.TypeName$) value);
					break;

$endif$