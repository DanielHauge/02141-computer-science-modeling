# Context Free Language Exercises

## Exercise 1.1

### a)
Set of all strings made of zero or many 0's:

P -> e | 0P

### b)
Set of all strings made of one or more 0's

P -> 0 | 0P

### c)
Set of all strings made of one or more 0's followed by one or more 1's

P -> 0 | 1 | 0P | P1 

### d)
Set of all strings made of one more 0's followed by an equal number of 1's

P -> 0P1 | 01


## Exercise 1.2
S -> A1B
A -> 0A | e
B -> 0B | 1B | e

### a)
A1B -> 0A1B -> 00A1B -> 001B -> 0010B -> 00101B -> 00101
A1B -> A10B -> A101B -> A101 -> 0A101 -> 00A101 -> 00101

### b)
A1B -> 1B -> 10B -> 100B -> 1001B -> 1001
A1B -> A1B -> A10B -> A100B -> A1001B -> A1001 -> 1001

### c)
A1B -> 0A1B -> 00A1B -> 000A1B -> 0001B -> 00011B -> 00011
A1B -> A11B -> A11 -> 0A11 -> 00A11 -> 000A11 -> 00011

## Exercise 1.3
Using http://jimblackler.net/treefun/ for tree generation.
### a)
```
S
 A
  0
  A
   0
   A
    e
 1
 B
  0
  B
   1
   B
    e
```
### b)
```
S
 A
  e
 1
 B
  0
  B
   0
   B
    1
    B
     e
```

### c)
```
S
 A
  0
  A
   0
   A
    0
    A
     e
 1
 B
  1
  B
   e
```
## Exercise 1.4

### b)
S -> P
P -> (P)

### c)
P -> 010 | 0P | P0

### d)
P -> 0P2 | A
A -> A1 | e

### e)
P -> APB | AB
A -> 0 | e
B -> 1

### f)
P -> APBB | ABB
A -> 0
B -> 1

## Exercise 1.5
Keeps tailing up, until epsilon, there is no more elements. (Empty list)
A -> 0A | 1A | e

## Exercist 1.6
maybe (A,A)
A -> AA | 0 | 1 | e

## Exercise 1.7
1) Yes
2) Depends
3) Depends