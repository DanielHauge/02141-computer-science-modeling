# RL3 - Exercises and solution sketches

## 3.1.1

### a)
```
(((a+b+c)* a (a+b+c)* b) + ((a+b+c)* b (a+b+c)* a))*
```

### b)
```
((0+1)* 1 (0+1){9}) + ((0+1){0,9})
```

### c)
```
(0+1) ((1 0)* + (0 1)*)
```

## 3.1.4

### a)
- Is able to begin with 1
- Contains none or many occurences of: atleast one zero followed by none or many zeroes and ending in 1
- Is able to end in none or many zeroes.

### b)
- Begins or ends with any sequence of zeroes or ones
- Contain atleast one occurence of 3 zeroes

### c)
- Sequence can never contain consecutive 1's unless it's part of the tail.

## 3.2.3
** done on paper ** - Resulting in:
```
(1+(0(10*11+01)*00)*)*
```

## 3.2.4

### a)

```
01*
```

<svg width="800" height="600" version="1.1" style="background-color:grey" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="138.5" cy="160.5" rx="30" ry="30"/>
	<text x="135.5" y="166.5" font-family="Times New Roman" font-size="20">i</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="138.5" cy="290.5" rx="30" ry="30"/>
	<text x="129.5" y="296.5" font-family="Times New Roman" font-size="20">s1</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="242.5" cy="290.5" rx="30" ry="30"/>
	<text x="233.5" y="296.5" font-family="Times New Roman" font-size="20">s2</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="366.5" cy="290.5" rx="30" ry="30"/>
	<text x="357.5" y="296.5" font-family="Times New Roman" font-size="20">s3</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="484.5" cy="290.5" rx="30" ry="30"/>
	<text x="475.5" y="296.5" font-family="Times New Roman" font-size="20">s4</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="606.5" cy="290.5" rx="30" ry="30"/>
	<text x="603.5" y="296.5" font-family="Times New Roman" font-size="20">f</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="606.5" cy="290.5" rx="24" ry="24"/>
	<polygon stroke="black" stroke-width="1" points="138.5,190.5 138.5,260.5"/>
	<polygon fill="black" stroke-width="1" points="138.5,260.5 143.5,252.5 133.5,252.5"/>
	<text x="125.5" y="231.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="168.5,290.5 212.5,290.5"/>
	<polygon fill="black" stroke-width="1" points="212.5,290.5 204.5,285.5 204.5,295.5"/>
	<text x="185.5" y="311.5" font-family="Times New Roman" font-size="20">0</text>
	<polygon stroke="black" stroke-width="1" points="396.5,290.5 454.5,290.5"/>
	<polygon fill="black" stroke-width="1" points="454.5,290.5 446.5,285.5 446.5,295.5"/>
	<text x="420.5" y="311.5" font-family="Times New Roman" font-size="20">1</text>
	<polygon stroke="black" stroke-width="1" points="272.5,290.5 336.5,290.5"/>
	<polygon fill="black" stroke-width="1" points="336.5,290.5 328.5,285.5 328.5,295.5"/>
	<text x="300.5" y="311.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="514.5,290.5 576.5,290.5"/>
	<polygon fill="black" stroke-width="1" points="576.5,290.5 568.5,285.5 568.5,295.5"/>
	<text x="541.5" y="311.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 371.106,261.179 A 59.28,59.28 0 0 1 479.894,261.179"/>
	<polygon fill="black" stroke-width="1" points="371.106,261.179 378.875,255.826 369.699,251.85"/>
	<text x="421.5" y="216.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 583.686,309.956 A 263.332,263.332 0 0 1 265.314,309.956"/>
	<polygon fill="black" stroke-width="1" points="583.686,309.956 574.29,310.809 580.335,318.775"/>
	<text x="420.5" y="384.5" font-family="Times New Roman" font-size="20">&#949;</text>
</svg>


### b)
```
(0+1)01
```
<svg width="800" height="600" version="1.1" style="background-color:grey" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="84.5" cy="307.5" rx="30" ry="30"/>
	<text x="81.5" y="313.5" font-family="Times New Roman" font-size="20">i</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="84.5" cy="199.5" rx="30" ry="30"/>
	<text x="75.5" y="205.5" font-family="Times New Roman" font-size="20">s1</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="84.5" cy="419.5" rx="30" ry="30"/>
	<text x="75.5" y="425.5" font-family="Times New Roman" font-size="20">s2</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="191.5" cy="199.5" rx="30" ry="30"/>
	<text x="182.5" y="205.5" font-family="Times New Roman" font-size="20">s3</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="191.5" cy="419.5" rx="30" ry="30"/>
	<text x="182.5" y="425.5" font-family="Times New Roman" font-size="20">s4</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="191.5" cy="307.5" rx="30" ry="30"/>
	<text x="182.5" y="313.5" font-family="Times New Roman" font-size="20">s5</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="291.5" cy="307.5" rx="30" ry="30"/>
	<text x="282.5" y="313.5" font-family="Times New Roman" font-size="20">s6</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="384.5" cy="307.5" rx="30" ry="30"/>
	<text x="375.5" y="313.5" font-family="Times New Roman" font-size="20">s7</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="487.5" cy="306.5" rx="30" ry="30"/>
	<text x="478.5" y="312.5" font-family="Times New Roman" font-size="20">s8</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="586.5" cy="306.5" rx="30" ry="30"/>
	<text x="577.5" y="312.5" font-family="Times New Roman" font-size="20">s9</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="696.5" cy="306.5" rx="30" ry="30"/>
	<text x="682.5" y="312.5" font-family="Times New Roman" font-size="20">s10</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="696.5" cy="306.5" rx="24" ry="24"/>
	<polygon stroke="black" stroke-width="1" points="84.5,277.5 84.5,229.5"/>
	<polygon fill="black" stroke-width="1" points="84.5,229.5 79.5,237.5 89.5,237.5"/>
	<text x="71.5" y="259.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="84.5,337.5 84.5,389.5"/>
	<polygon fill="black" stroke-width="1" points="84.5,389.5 89.5,381.5 79.5,381.5"/>
	<text x="71.5" y="369.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="114.5,419.5 161.5,419.5"/>
	<polygon fill="black" stroke-width="1" points="161.5,419.5 153.5,414.5 153.5,424.5"/>
	<text x="133.5" y="440.5" font-family="Times New Roman" font-size="20">1</text>
	<polygon stroke="black" stroke-width="1" points="114.5,199.5 161.5,199.5"/>
	<polygon fill="black" stroke-width="1" points="161.5,199.5 153.5,194.5 153.5,204.5"/>
	<text x="133.5" y="220.5" font-family="Times New Roman" font-size="20">0</text>
	<polygon stroke="black" stroke-width="1" points="191.5,229.5 191.5,277.5"/>
	<polygon fill="black" stroke-width="1" points="191.5,277.5 196.5,269.5 186.5,269.5"/>
	<text x="178.5" y="259.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="191.5,389.5 191.5,337.5"/>
	<polygon fill="black" stroke-width="1" points="191.5,337.5 186.5,345.5 196.5,345.5"/>
	<text x="178.5" y="369.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="321.5,307.5 354.5,307.5"/>
	<polygon fill="black" stroke-width="1" points="354.5,307.5 346.5,302.5 346.5,312.5"/>
	<text x="333.5" y="328.5" font-family="Times New Roman" font-size="20">0</text>
	<polygon stroke="black" stroke-width="1" points="517.5,306.5 556.5,306.5"/>
	<polygon fill="black" stroke-width="1" points="556.5,306.5 548.5,301.5 548.5,311.5"/>
	<text x="532.5" y="327.5" font-family="Times New Roman" font-size="20">1</text>
	<polygon stroke="black" stroke-width="1" points="221.5,307.5 261.5,307.5"/>
	<polygon fill="black" stroke-width="1" points="261.5,307.5 253.5,302.5 253.5,312.5"/>
	<text x="237.5" y="328.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="414.499,307.209 457.501,306.791"/>
	<polygon fill="black" stroke-width="1" points="457.501,306.791 449.453,301.869 449.55,311.869"/>
	<text x="429.5" y="328.5" font-family="Times New Roman" font-size="20"> &#949;</text>
	<polygon stroke="black" stroke-width="1" points="616.5,306.5 666.5,306.5"/>
	<polygon fill="black" stroke-width="1" points="666.5,306.5 658.5,301.5 658.5,311.5"/>
	<text x="637.5" y="327.5" font-family="Times New Roman" font-size="20">&#949;</text>
</svg>


### c)
```
00(0+1)*
```

<svg width="800" height="600" version="1.1" style="background-color:grey" xmlns="http://www.w3.org/2000/svg">
	<ellipse stroke="black" stroke-width="1" fill="none" cx="105.5" cy="206.5" rx="30" ry="30"/>
	<text x="102.5" y="212.5" font-family="Times New Roman" font-size="20">i</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="105.5" cy="330.5" rx="30" ry="30"/>
	<text x="96.5" y="336.5" font-family="Times New Roman" font-size="20">s0</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="210.5" cy="330.5" rx="30" ry="30"/>
	<text x="201.5" y="336.5" font-family="Times New Roman" font-size="20">s1</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="210.5" cy="433.5" rx="30" ry="30"/>
	<text x="201.5" y="439.5" font-family="Times New Roman" font-size="20">s2</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="302.5" cy="433.5" rx="30" ry="30"/>
	<text x="293.5" y="439.5" font-family="Times New Roman" font-size="20">s3</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="403.5" cy="330.5" rx="30" ry="30"/>
	<text x="394.5" y="336.5" font-family="Times New Roman" font-size="20">s4</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="403.5" cy="225.5" rx="30" ry="30"/>
	<text x="394.5" y="231.5" font-family="Times New Roman" font-size="20">s5</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="403.5" cy="425.5" rx="30" ry="30"/>
	<text x="394.5" y="431.5" font-family="Times New Roman" font-size="20">s6</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="510.5" cy="425.5" rx="30" ry="30"/>
	<text x="501.5" y="431.5" font-family="Times New Roman" font-size="20">s7</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="510.5" cy="225.5" rx="30" ry="30"/>
	<text x="501.5" y="231.5" font-family="Times New Roman" font-size="20">s8</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="510.5" cy="330.5" rx="30" ry="30"/>
	<text x="501.5" y="336.5" font-family="Times New Roman" font-size="20">s9</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="618.5" cy="330.5" rx="30" ry="30"/>
	<text x="604.5" y="336.5" font-family="Times New Roman" font-size="20">s10</text>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="618.5" cy="330.5" rx="24" ry="24"/>
	<ellipse stroke="black" stroke-width="1" fill="none" cx="302.5" cy="330.5" rx="30" ry="30"/>
	<text x="288.5" y="336.5" font-family="Times New Roman" font-size="20">s11</text>
	<polygon stroke="black" stroke-width="1" points="105.5,236.5 105.5,300.5"/>
	<polygon fill="black" stroke-width="1" points="105.5,300.5 110.5,292.5 100.5,292.5"/>
	<text x="92.5" y="274.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="135.5,330.5 180.5,330.5"/>
	<polygon fill="black" stroke-width="1" points="180.5,330.5 172.5,325.5 172.5,335.5"/>
	<text x="153.5" y="351.5" font-family="Times New Roman" font-size="20">0</text>
	<polygon stroke="black" stroke-width="1" points="210.5,360.5 210.5,403.5"/>
	<polygon fill="black" stroke-width="1" points="210.5,403.5 215.5,395.5 205.5,395.5"/>
	<text x="197.5" y="388.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="240.5,433.5 272.5,433.5"/>
	<polygon fill="black" stroke-width="1" points="272.5,433.5 264.5,428.5 264.5,438.5"/>
	<text x="251.5" y="454.5" font-family="Times New Roman" font-size="20">0</text>
	<polygon stroke="black" stroke-width="1" points="302.5,403.5 302.5,360.5"/>
	<polygon fill="black" stroke-width="1" points="302.5,360.5 297.5,368.5 307.5,368.5"/>
	<text x="307.5" y="388.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="332.5,330.5 373.5,330.5"/>
	<polygon fill="black" stroke-width="1" points="373.5,330.5 365.5,325.5 365.5,335.5"/>
	<text x="348.5" y="351.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="403.5,300.5 403.5,255.5"/>
	<polygon fill="black" stroke-width="1" points="403.5,255.5 398.5,263.5 408.5,263.5"/>
	<text x="408.5" y="284.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="403.5,360.5 403.5,395.5"/>
	<polygon fill="black" stroke-width="1" points="403.5,395.5 408.5,387.5 398.5,387.5"/>
	<text x="390.5" y="384.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="433.5,425.5 480.5,425.5"/>
	<polygon fill="black" stroke-width="1" points="480.5,425.5 472.5,420.5 472.5,430.5"/>
	<text x="452.5" y="446.5" font-family="Times New Roman" font-size="20">1</text>
	<polygon stroke="black" stroke-width="1" points="433.5,225.5 480.5,225.5"/>
	<polygon fill="black" stroke-width="1" points="480.5,225.5 472.5,220.5 472.5,230.5"/>
	<text x="452.5" y="246.5" font-family="Times New Roman" font-size="20">0</text>
	<polygon stroke="black" stroke-width="1" points="510.5,395.5 510.5,360.5"/>
	<polygon fill="black" stroke-width="1" points="510.5,360.5 505.5,368.5 515.5,368.5"/>
	<text x="515.5" y="384.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="510.5,255.5 510.5,300.5"/>
	<polygon fill="black" stroke-width="1" points="510.5,300.5 515.5,292.5 505.5,292.5"/>
	<text x="497.5" y="284.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="480.5,330.5 433.5,330.5"/>
	<polygon fill="black" stroke-width="1" points="433.5,330.5 441.5,335.5 441.5,325.5"/>
	<text x="452.5" y="321.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<polygon stroke="black" stroke-width="1" points="540.5,330.5 588.5,330.5"/>
	<polygon fill="black" stroke-width="1" points="588.5,330.5 580.5,325.5 580.5,335.5"/>
	<text x="560.5" y="351.5" font-family="Times New Roman" font-size="20">&#949;</text>
	<path stroke="black" stroke-width="1" fill="none" d="M 297.381,300.983 A 163.643,163.643 0 1 1 623.619,300.983"/>
	<polygon fill="black" stroke-width="1" points="623.619,300.983 629.243,293.408 619.275,292.608"/>
	<text x="456.5" y="115.5" font-family="Times New Roman" font-size="20">&#949;</text>
</svg>

