# Formal Methods Part 2 Exercises. (FM2)
Exercises: 2.6 2.11 2.16 2.20

## 2.6
Exercise 2.6: Construct programs in the Guarded Commands language computing
### (a) 
The modulo operation 𝗆𝗈𝖽(𝑛,𝑚) returning the remainder after division of one number 𝑛 by another 𝑚;

``` n = 5, m = 10, x = 0, y = 0 ```
```
x:=n;
y:=m;
do x>=y -> x:=x-m od
```


### (b) 
The greatest common divisor 𝗀𝖼𝖽(𝑛,𝑚) of two numbers 𝑛 and 𝑚;

``` n = 5, m = 10, x = 0, y = 0, xTemp = 0 ```
```
x := n;
y := m;
do !(y=0) -> do x >= y -> x := x-y od; 
              xTemp := x;
              x := y;
              y := xTemp
od
```

### (c) 
The 𝑛’th Fibonacci number.

```a = 0, b=1, c=1, i =0, n=8, z=0```
```
if n=0 -> z := a
[] true -> i:=2 ; do !(i>n) -> i:=i+1; c:=a+b; a:=b; b:=c od
fi;
z := b
```


## 2.11
Well yes, the guarded commands programs are made based on the graphs. Translating back will just result in the same graph?. 

## 2.16
- B[[false]]𝜎 = false
- B[[a1!=a2]]𝜎 = false if B[[a1]]𝜎 and B[[a2]]𝜎 otherwise true
- B[[b1<b2]]𝜎 = ¬B[[b1>=b2]]𝜎
- B[[b1<=b2]]𝜎 = ¬B[[b1>b2]]𝜎
- B[[b1 ∨ b2]]𝜎 = true if B[[b1]]𝜎=true, true if B[[b2]]𝜎=true, otherwise false


