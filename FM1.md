# Formal Methods Part 1 Exercises. (FM1)
Exercises: 1.5 1.9 1.18 1.19

## 1.5 
Specify program graphs for the functions below using actions that
are simple tests and assignments (similar to the ones used in Example 1.1):
- (a) the modulo operation 𝗆𝗈𝖽(𝑛,𝑚) returning the remainder after division of one number 𝑛 by another 𝑚;
- (b) the greatest common divisor 𝗀𝖼𝖽(𝑛,𝑚) of two numbers 𝑛 and 𝑚;
- (c) the 𝑛’th Fibonacci number.

### a)

<svg width="800" height="600" style="background-color:grey" version="1.1" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="109.5" cy="302.5" rx="30" ry="30"/>
	<text x="92.5" y="308.5" font-family="Times New Roman" font-size="20">start</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="280.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="168.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="560.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="560.5" cy="302.5" rx="24" ry="24"/>
	<polygon stroke="black" stroke-width="1" points="139.5,302.5 250.5,302.5"/>
	<polygon fill="black" stroke-width="1" points="250.5,302.5 242.5,297.5 242.5,307.5"/>
	<text x="176.5" y="323.5" font-family="Times New Roman" font-size="20">x:=n</text>
	<polygon stroke="black" stroke-width="1" points="310.5,302.5 405.5,302.5"/>
	<polygon fill="black" stroke-width="1" points="405.5,302.5 397.5,297.5 397.5,307.5"/>
	<text x="336.5" y="323.5" font-family="Times New Roman" font-size="20">y:=m</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 454.654,191.4 A 87.861,87.861 0 0 1 454.654,279.6"/>
	<polygon fill="black" stroke-width="1" points="454.654,191.4 454.345,200.829 462.994,195.81"/>
	<text x="471.5" y="241.5" font-family="Times New Roman" font-size="20">x=&gt;y</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 418.349,278.033 A 96.576,96.576 0 0 1 418.349,192.967"/>
	<polygon fill="black" stroke-width="1" points="418.349,278.033 419.315,268.648 410.337,273.052"/>
	<text x="344.5" y="241.5" font-family="Times New Roman" font-size="20">x:=x-m</text>
	<polygon stroke="black" stroke-width="1" points="465.5,302.5 530.5,302.5"/>
	<polygon fill="black" stroke-width="1" points="530.5,302.5 522.5,297.5 522.5,307.5"/>
	<text x="482.5" y="323.5" font-family="Times New Roman" font-size="20">x&lt;y</text>
</svg>

### b)

<svg width="800" height="600" style="background-color:grey" version="1.1" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="175.5" rx="30" ry="30"/>
	<text x="80.5" y="181.5" font-family="Times New Roman" font-size="20">start</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="612.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="191.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="261.5" cy="302.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="460.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="460.5" rx="24" ry="24"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="261.5" cy="460.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="435.5" cy="81.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="261.5" cy="81.5" rx="30" ry="30"/>
	<polygon stroke="black" stroke-width="1" points="97.5,205.5 97.5,272.5"/>
	<polygon fill="black" stroke-width="1" points="97.5,272.5 102.5,264.5 92.5,264.5"/>
	<text x="55.5" y="245.5" font-family="Times New Roman" font-size="20">x:=n</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 587.266,318.621 A 141.739,141.739 0 0 1 460.734,318.621"/>
	<polygon fill="black" stroke-width="1" points="587.266,318.621 577.876,317.718 582.339,326.667"/>
	<text x="502.5" y="354.5" font-family="Times New Roman" font-size="20">x=&gt;y</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 461.817,288.191 A 158.434,158.434 0 0 1 586.183,288.191"/>
	<polygon fill="black" stroke-width="1" points="461.817,288.191 471.137,289.65 467.212,280.452"/>
	<text x="497.5" y="266.5" font-family="Times New Roman" font-size="20">x:=x-y</text>
	<polygon stroke="black" stroke-width="1" points="435.5,272.5 435.5,221.5"/>
	<polygon fill="black" stroke-width="1" points="435.5,221.5 430.5,229.5 440.5,229.5"/>
	<text x="440.5" y="253.5" font-family="Times New Roman" font-size="20">x&lt;y</text>
	<polygon stroke="black" stroke-width="1" points="291.5,302.5 405.5,302.5"/>
	<polygon fill="black" stroke-width="1" points="405.5,302.5 397.5,297.5 397.5,307.5"/>
	<text x="329.5" y="293.5" font-family="Times New Roman" font-size="20">y!=0</text>
	<polygon stroke="black" stroke-width="1" points="127.5,302.5 231.5,302.5"/>
	<polygon fill="black" stroke-width="1" points="231.5,302.5 223.5,297.5 223.5,307.5"/>
	<text x="158.5" y="323.5" font-family="Times New Roman" font-size="20">y:=m</text>
	<polygon stroke="black" stroke-width="1" points="261.5,332.5 261.5,430.5"/>
	<polygon fill="black" stroke-width="1" points="261.5,430.5 266.5,422.5 256.5,422.5"/>
	<text x="213.5" y="387.5" font-family="Times New Roman" font-size="20">y==0</text>
	<polygon stroke="black" stroke-width="1" points="291.5,460.5 405.5,460.5"/>
	<polygon fill="black" stroke-width="1" points="405.5,460.5 397.5,455.5 397.5,465.5"/>
	<text x="317.5" y="481.5" font-family="Times New Roman" font-size="20">return x</text>
	<polygon stroke="black" stroke-width="1" points="435.5,161.5 435.5,111.5"/>
	<polygon fill="black" stroke-width="1" points="435.5,111.5 430.5,119.5 440.5,119.5"/>
	<text x="440.5" y="142.5" font-family="Times New Roman" font-size="20">xTemp := x</text>
	<polygon stroke="black" stroke-width="1" points="405.5,81.5 291.5,81.5"/>
	<polygon fill="black" stroke-width="1" points="291.5,81.5 299.5,86.5 299.5,76.5"/>
	<text x="330.5" y="72.5" font-family="Times New Roman" font-size="20">x:=y</text>
	<polygon stroke="black" stroke-width="1" points="261.5,111.5 261.5,272.5"/>
	<polygon fill="black" stroke-width="1" points="261.5,272.5 266.5,264.5 256.5,264.5"/>
	<text x="174.5" y="198.5" font-family="Times New Roman" font-size="20">y:=xTemp</text>
</svg>

### c)

<svg width="800" height="600" style="background-color:grey" version="1.1" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="175.5" rx="30" ry="30"/>
	<text x="80.5" y="181.5" font-family="Times New Roman" font-size="20">start</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="266.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="361.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="219.5" cy="361.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="219.5" cy="482.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="364.5" cy="482.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="364.5" cy="482.5" rx="24" ry="24"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="364.5" cy="272.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="364.5" cy="361.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="219.5" cy="272.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="364.5" cy="175.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="364.5" cy="66.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="512.5" cy="66.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="512.5" cy="272.5" rx="30" ry="30"/>
	<polygon stroke="black" stroke-width="1" points="97.5,205.5 97.5,236.5"/>
	<polygon fill="black" stroke-width="1" points="97.5,236.5 102.5,228.5 92.5,228.5"/>
	<text x="56.5" y="227.5" font-family="Times New Roman" font-size="20">a:=0</text>
	<polygon stroke="black" stroke-width="1" points="97.5,296.5 97.5,331.5"/>
	<polygon fill="black" stroke-width="1" points="97.5,331.5 102.5,323.5 92.5,323.5"/>
	<text x="55.5" y="320.5" font-family="Times New Roman" font-size="20">b:=1</text>
	<polygon stroke="black" stroke-width="1" points="127.5,361.5 189.5,361.5"/>
	<polygon fill="black" stroke-width="1" points="189.5,361.5 181.5,356.5 181.5,366.5"/>
	<text x="140.5" y="382.5" font-family="Times New Roman" font-size="20">c:=1</text>
	<polygon stroke="black" stroke-width="1" points="219.5,391.5 219.5,452.5"/>
	<polygon fill="black" stroke-width="1" points="219.5,452.5 224.5,444.5 214.5,444.5"/>
	<text x="171.5" y="428.5" font-family="Times New Roman" font-size="20">n==0</text>
	<polygon stroke="black" stroke-width="1" points="249.5,482.5 334.5,482.5"/>
	<polygon fill="black" stroke-width="1" points="334.5,482.5 326.5,477.5 326.5,487.5"/>
	<text x="261.5" y="503.5" font-family="Times New Roman" font-size="20">return a</text>
	<polygon stroke="black" stroke-width="1" points="364.5,302.5 364.5,331.5"/>
	<polygon fill="black" stroke-width="1" points="364.5,331.5 369.5,323.5 359.5,323.5"/>
	<text x="332.5" y="323.5" font-family="Times New Roman" font-size="20">i&gt;n</text>
	<polygon stroke="black" stroke-width="1" points="364.5,391.5 364.5,452.5"/>
	<polygon fill="black" stroke-width="1" points="364.5,452.5 369.5,444.5 359.5,444.5"/>
	<text x="296.5" y="428.5" font-family="Times New Roman" font-size="20">return b</text>
	<polygon stroke="black" stroke-width="1" points="219.5,331.5 219.5,302.5"/>
	<polygon fill="black" stroke-width="1" points="219.5,302.5 214.5,310.5 224.5,310.5"/>
	<text x="224.5" y="323.5" font-family="Times New Roman" font-size="20">n!=0</text>
	<polygon stroke="black" stroke-width="1" points="249.5,272.5 334.5,272.5"/>
	<polygon fill="black" stroke-width="1" points="334.5,272.5 326.5,267.5 326.5,277.5"/>
	<text x="275.5" y="293.5" font-family="Times New Roman" font-size="20">i:=2</text>
	<polygon stroke="black" stroke-width="1" points="364.5,242.5 364.5,205.5"/>
	<polygon fill="black" stroke-width="1" points="364.5,205.5 359.5,213.5 369.5,213.5"/>
	<text x="369.5" y="230.5" font-family="Times New Roman" font-size="20">!(i&gt;n)</text>
	<polygon stroke="black" stroke-width="1" points="364.5,145.5 364.5,96.5"/>
	<polygon fill="black" stroke-width="1" points="364.5,96.5 359.5,104.5 369.5,104.5"/>
	<text x="369.5" y="127.5" font-family="Times New Roman" font-size="20">i++</text>
	<polygon stroke="black" stroke-width="1" points="394.5,66.5 482.5,66.5"/>
	<polygon fill="black" stroke-width="1" points="482.5,66.5 474.5,61.5 474.5,71.5"/>
	<text x="408.5" y="87.5" font-family="Times New Roman" font-size="20">c:= a+b</text>
	<polygon stroke="black" stroke-width="1" points="512.5,96.5 512.5,242.5"/>
	<polygon fill="black" stroke-width="1" points="512.5,242.5 517.5,234.5 507.5,234.5"/>
	<text x="471.5" y="175.5" font-family="Times New Roman" font-size="20">a:=b</text>
	<polygon stroke="black" stroke-width="1" points="482.5,272.5 394.5,272.5"/>
	<polygon fill="black" stroke-width="1" points="394.5,272.5 402.5,277.5 402.5,267.5"/>
	<text x="420.5" y="263.5" font-family="Times New Roman" font-size="20">b:=c</text>
</svg>

## 1.9

- S\[\[x:=n]] (vx,vy) = (n,vy)
- S\[\[y:=m]] (vx,vy) = (vx,m)
- S\[\[x:=x-m]] (vx,vy) = (vx-m, vy)
- S\[\[x=>y]] (vx,vy) = (vx,vy) if x => y otherwise undefined
- S\[\[x<y]] (vx,vy) = (vx,vy) if x < y otherwise undefined


## 1.18

<?xml version="1.0" standalone="no"?>
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">

<svg width="800" height="600" style="background-color:grey" version="1.1" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="175.5" rx="30" ry="30"/>
	<text x="80.5" y="181.5" font-family="Times New Roman" font-size="20">start</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="254.5" cy="175.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="254.5" cy="288.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="410.5" cy="288.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="288.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="97.5" cy="288.5" rx="24" ry="24"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="410.5" cy="175.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="653.5" cy="406.5" rx="30" ry="30"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="410.5" cy="406.5" rx="30" ry="30"/>
	<polygon stroke="black" stroke-width="1" points="127.5,175.5 224.5,175.5"/>
	<polygon fill="black" stroke-width="1" points="224.5,175.5 216.5,170.5 216.5,180.5"/>
	<text x="159.5" y="196.5" font-family="Times New Roman" font-size="20">i:=0</text>
	<polygon stroke="black" stroke-width="1" points="254.5,205.5 254.5,258.5"/>
	<polygon fill="black" stroke-width="1" points="254.5,258.5 259.5,250.5 249.5,250.5"/>
	<text x="217.5" y="238.5" font-family="Times New Roman" font-size="20">j:=0</text>
	<polygon stroke="black" stroke-width="1" points="284.5,288.5 380.5,288.5"/>
	<polygon fill="black" stroke-width="1" points="380.5,288.5 372.5,283.5 372.5,293.5"/>
	<text x="305.5" y="309.5" font-family="Times New Roman" font-size="20">i &lt; n-1</text>
	<polygon stroke="black" stroke-width="1" points="224.5,288.5 127.5,288.5"/>
	<polygon fill="black" stroke-width="1" points="127.5,288.5 135.5,293.5 135.5,283.5"/>
	<text x="139.5" y="279.5" font-family="Times New Roman" font-size="20">!(i &lt; n-1)</text>
	<polygon stroke="black" stroke-width="1" points="386.204,193.099 278.796,270.901"/>
	<polygon fill="black" stroke-width="1" points="278.796,270.901 288.208,270.257 282.341,262.159"/>
	<text x="299.5" y="223.5" font-family="Times New Roman" font-size="20">i++</text>
	<polygon stroke="black" stroke-width="1" points="410.5,258.5 410.5,205.5"/>
	<polygon fill="black" stroke-width="1" points="410.5,205.5 405.5,213.5 415.5,213.5"/>
	<text x="415.5" y="238.5" font-family="Times New Roman" font-size="20">!(j &gt; n-i-1)</text>
	<polygon stroke="black" stroke-width="1" points="626.514,393.395 437.486,301.605"/>
	<polygon fill="black" stroke-width="1" points="437.486,301.605 442.499,309.597 446.867,300.601"/>
	<text x="536.5" y="338.5" font-family="Times New Roman" font-size="20">j++</text>
	<polygon stroke="black" stroke-width="1" points="410.5,318.5 410.5,376.5"/>
	<polygon fill="black" stroke-width="1" points="410.5,376.5 415.5,368.5 405.5,368.5"/>
	<text x="339.5" y="353.5" font-family="Times New Roman" font-size="20">j &gt; n-i-1</text>
	<polygon stroke="black" stroke-width="1" points="440.5,406.5 623.5,406.5"/>
	<polygon fill="black" stroke-width="1" points="623.5,406.5 615.5,401.5 615.5,411.5"/>
	<text x="467.5" y="427.5" font-family="Times New Roman" font-size="20">!(A[j] &gt; A[j+1])</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 642.904,434.49 A 125.148,125.148 0 0 1 421.096,434.49"/>
	<polygon fill="black" stroke-width="1" points="642.904,434.49 634.766,439.263 643.628,443.896"/>
	<text x="471.5" y="522.5" font-family="Times New Roman" font-size="20">swap(A, j, j+1)</text>
</svg>

