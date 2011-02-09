@echo off

call "C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\vcvarsall.bat" x86

@echo on

java -jar trang.jar "collection\model.xml" "composition\model.xml" "immutable\model.xml" "implements\model.xml" "lazy\model.xml" "noNamespace\model.xml" "noncloneable\model.xml" "nonserializable\model.xml"  "privateSetter\model.xml" "projectNamespace\model.xml" "required\model.xml" "simple\model.xml" "using\model.xml" "computed-property\model.xml" "doc\model.xml" "extends\model.xml" model_xml.xsd

xsd model_xml.xsd /classes /n:org.pescuma.ModelSharp.Core.xml /out:..\Core\xml

pause
