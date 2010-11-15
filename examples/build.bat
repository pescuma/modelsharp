@echo off

call "C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\vcvarsall.bat" x86

java -jar trang.jar "simple\model.xml" "immutable\model.xml" "composition\model.xml" "collection\model.xml" "lazy\model.xml" "using\model.xml" "required\model.xml" "privateSetter\model.xml" model_xml.xsd

xsd model_xml.xsd /classes /n:org.pescuma.ModelSharp.Core.xml /out:..\ModelSharp.Core\xml

pause
