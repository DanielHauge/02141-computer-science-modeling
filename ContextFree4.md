# Context Free languages lecture 4.

# 4.1

## 1) Drawing
<?xml version="1.0" standalone="no"?>
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">

<svg width="800" height="600" style="background-color:grey" version="1.1" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="75.5" cy="288.5" rx="30" ry="30"/>
	<text x="58.5" y="294.5" font-family="Times New Roman" font-size="20">start</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="260.5" cy="288.5" rx="30" ry="30"/>
	<text x="238.5" y="294.5" font-family="Times New Roman" font-size="20">guess</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="417.5" cy="288.5" rx="30" ry="30"/>
	<text x="394.5" y="294.5" font-family="Times New Roman" font-size="20">check</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="592.5" cy="288.5" rx="30" ry="30"/>
	<text x="570.5" y="294.5" font-family="Times New Roman" font-size="20">right!</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="592.5" cy="288.5" rx="24" ry="24"/>
	<polygon stroke="black" stroke-width="1" points="105.5,288.5 230.5,288.5"/>
	<polygon fill="black" stroke-width="1" points="230.5,288.5 222.5,283.5 222.5,293.5"/>
	<text x="127.5" y="309.5" font-family="Times New Roman" font-size="20">&#949;, Z&#8320; / SZ&#8320;</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 247.275,261.703 A 22.5,22.5 0 1 1 273.725,261.703"/>
	<text x="227.5" y="212.5" font-family="Times New Roman" font-size="20">&#949;, S / S0</text>
	<polygon fill="black" stroke-width="1" points="273.725,261.703 282.473,258.17 274.382,252.292"/>
	<polygon stroke="black" stroke-width="1" points="290.5,288.5 387.5,288.5"/>
	<polygon fill="black" stroke-width="1" points="387.5,288.5 379.5,283.5 379.5,293.5"/>
	<text x="312.5" y="309.5" font-family="Times New Roman" font-size="20">&#949;, S / &#949;</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 404.275,261.703 A 22.5,22.5 0 1 1 430.725,261.703"/>
	<text x="390.5" y="212.5" font-family="Times New Roman" font-size="20">0, 0 / &#949;</text>
	<polygon fill="black" stroke-width="1" points="430.725,261.703 439.473,258.17 431.382,252.292"/>
	<path stroke="black" stroke-width="1" fill="none" d="M 430.725,315.297 A 22.5,22.5 0 1 1 404.275,315.297"/>
	<text x="390.5" y="377.5" font-family="Times New Roman" font-size="20">1, 1 / &#949;</text>
	<polygon fill="black" stroke-width="1" points="404.275,315.297 395.527,318.83 403.618,324.708"/>
	<polygon stroke="black" stroke-width="1" points="447.5,288.5 562.5,288.5"/>
	<polygon fill="black" stroke-width="1" points="562.5,288.5 554.5,283.5 554.5,293.5"/>
	<text x="474.5" y="309.5" font-family="Times New Roman" font-size="20">&#949;, Z&#8320; / &#949;</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 273.725,315.297 A 22.5,22.5 0 1 1 247.275,315.297"/>
	<text x="227.5" y="377.5" font-family="Times New Roman" font-size="20">&#949;, S / S1</text>
	<polygon fill="black" stroke-width="1" points="247.275,315.297 238.527,318.83 246.618,324.708"/>
</svg>

## 2)
- $(start, 010, Z_0)$
- $(guess, 010, SZ_0)$
- $(guess, 010, S1Z_0)$
- $(check, 010, 1Z_0)$
  
Nope, I do not have a (0, 1 / ..) path.
Only 1,1 or 0,0. It has to match. Do not accept.

## 3)
- $(start, 010, Z_0)$
- $(guess, 010, SZ_0)$
- $(check, 010, Z_0)$
- $(right!, 010, \epsilon)$

Well we are here. but we have not read the entire string tho.

## 4)
- $(start, 010, Z_0)$
- $(guess, 010, S0Z_0)$
- $(guess, 010, S10Z_0)$
- $(guess, 010, S010Z_0)$
- $(check, 010, 010Z_0)$
- $(check, 10, 10Z_0)$
- $(check, 0, 0Z_0)$
- $(check, \epsilon, Z_0)$
- $(right!, \epsilon, \epsilon)$
  
We are stuck at right! with no string left. Its good. we accept.

# 4.2
Lad os lige forme den bedre:

E -> 0 | 1 | (E) | ET 
T -> +E | *E 

PDA = ({e,t}, {0,1,+,*},{0,1,E}, f, e)

$f(e,\epsilon, E) = {(e, 2), (e, 1), (e, (e)), (t, ET))}$
$f(t,+, +) = {(e, +)}$
$f(t,*, *) = {(e, *)}$
$f(e,0, 0) = {(e, \epsilon)}$
$f(e,1, 1) = {(e, \epsilon)}$

# 4.3

# 4.4
## 1
We can do this in such a way, that for those states we want to be final states, we can make a inifinite pop statement. For the specific example, lets assume q to be final state. We will just add:

$\delta(q, \epsilon, \_) = {(q, \epsilon)}$


## 2
We can extend the PDA with a new initial state which can only proceed with putting a "finish" symbol at the buttom of the stack and on for each final state we can put a new transition which tries to consume the finish symbol. If that happens fine, it empties the stack.

Adding lets say GG as initial state, and F as the finish symbol terminal.

$\delta(GG, \epsilon, \_) = {(q, F)}$ => GG is new initial state which produces F to stack and will only allow final states to consume F, hence emptying the stack.

$\delta(q, \epsilon, F) = {(q, \epsilon)}$ => q is final state here. This accepts when F is consumed as stack will be empty then.

# 4.5
## a)
- $(q, 01, Z_0) \rArr (q, 1, XZ_0) \rArr (q, \epsilon, XZ_0) \rArr (p, \epsilon, Z_0)$ 
- $(q, 01, Z_0) \rArr (q, 1, XZ_0) \rArr (p, \epsilon, XXZ_0) \rArr (p, \epsilon, XZ_0) \rArr (p, \epsilon, Z_0)$

## b)
- $(q, 0011, Z_0) \rArr (q, 011, XZ_0) \rArr (q, 11, XXZ_0) \rArr (q,1,XXXZ_0) \rArr (q,\epsilon,XXXXZ_0)$
Eller gå med p.

## c)
- $(q, 010, Z_0) \rArr (q, 10, XZ_0) \rArr (q, 0, XXZ_0) \rArr (q, \epsilon, XXXXZ_0) \rArr (p, \epsilon, Z_0)$

# 4.6
- E -> 0E1 | 01
## a)
$PDA P = ({e0,e1,f},(0,1), (Z_0, X), f, e0, Z_0, GG)$
- $f(e0, 0, Z_0) = (e0, XZ_0)$  
- $f(e0, 0, X) = (e0, XX)$
- $f(e0, 1, X) = (e1, \epsilon)$
- $f(e1, 1, X) = (e1, \epsilon)$
- $f(e1,\epsilon, Z_0) = (GG, \epsilon)$

Enten ved at komme til GG, eller ved empty stack.

# 4.7
L(P) = we need to finish in state f.

## a)
- $(q_0, bab, Z_0)$
- $(q_2, ab, BZ_0)$
- $(q_3, b, Z_0)$
- $(q_1, b, AZ_0)$
- $(q_1, \epsilon, Z_0)$
- $(q_0, \epsilon, Z_0)$
- $(f, \epsilon, \epsilon)$

## b)
- $(q_0, abb, Z_0)$
- $(q_1, bb, AAZ_0)$
- $(q_1, b, AZ_0)$
- $(q_1, \epsilon, Z_0)$
- $(q_0, \epsilon, Z_0)$
- $(f, \epsilon, \epsilon)$
