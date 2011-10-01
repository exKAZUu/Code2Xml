var Student = function(name) {
    this.name = name;
    this.getName = function() {
        return this.name;
    };
};

var list = new Array(2);
list[0] = new Student("Tom");
list[1] = new Student("Anna");

var i = 0;
for(i = 0; i < 2; i++) {
   alert(list[i].getName());
}