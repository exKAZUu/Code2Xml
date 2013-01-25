function func() {
	i = 0;
	
	if (i == 0)
		alert("test");
	
	switch(i) {
		case 0:
		alert("test");
	}
	
	while (i != 0)
		alert("test");
	
	do
		alert("test");
	while (i != 0);
	
	for (i = 0; i < 0; i++)
		alert("test");

	for (i in new Array())
		alert("test");
	
	obj = { a: 1 }
	with(obj)
		alert(a)

	return 0;
}
