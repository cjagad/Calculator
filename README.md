# Calculator
Calculator

WPF	is	a	UI	framework	bundled	with	.NET	3	and	above.	WPF	uses	XAML	which	is	a	XML	based	
language	to	define	the	GUI.	We	currently	use	.NET	framework	4.7.2	but	you	can	use	any	.Net	
version	you	choose.
The	assignment	is	to	create	a	binary	calculator	as	a	standalone	WPF	application	which	for	fills	
these	requirements:

  • GUI	must	be	written	in	XAML	(WPF)
  • GUI	elements	must	scale	with	the	window	size.	So	if	the	user	makes	the	application’s	window larger	then	the	buttons	should	also	become	larger.
  • UI	does	not	need	to	have	same	layout	as	the	picture	which	is	shown	below,	just	use	that	as	an example	of	one	solution.
  • Needs	to	support	both	addition	and	subtraction	operations
  • Possibility	to	press	equals	several	times	to	repeat	an	operation
  • Display	which	shows	result	needs	to	toggle	between	showing	result	and	showing	userinput based	on	last	user	interaction.	For	example	if	user	presses	"1" then	display	should	show	input	but	if	user	presses	"="	then	display	should	show	result.
• Does	not	need	to	support	negative	results.

8	GUI	Elements:
  • “1”	and	“0”	buttons	for	inputing	0	and	1s.
  • “-“	and	“+”	buttons	for	subtraction	and	addition
  • “CE”	button	which	clears	last	entry	or	number.	(So	if	you	hit	wrong	input	then	CE	clears	it)
  • “C”	button	which	clears	everything
  • “=”	button	which	performs	operation
  • Display	field	which	shows	last	input/result
