class Student
  def initialize(name)
    @name = name
  end
  
  def name()
    @name
  end
end

students = Array.new(2)
students[0] = Student.new('Tom')
students[1] = Student.new('Anna')

for student in students
  puts student.name
end
