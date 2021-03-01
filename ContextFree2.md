ContextFree 2 Exercises.

Exercise 2.2
Json grammar:

Value -> String | Number | Obj | Array | true | false | null;
Obj -> { Pairs }
Pairs -> Pair, Pairs | e
Pair -> String:Value
Objs -> Obj, Objs | e
Array -> [Objs]
Number -> [0-9]+                    ie.  0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | NumberNumber
String -> [a-Z]*

Exercise 2.3

not true or not true or not true


(not true) or (not true) 
