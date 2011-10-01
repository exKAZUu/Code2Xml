i = 0

p i if i == 0
if i == 0 then p 'c'; p 'c'; end
if i == 0 then p 'c' end
if i == 0 then end
if i == 0; p 'c'; p 'c'; end
if i == 0; p 'c' end
if i == 0; end
if i == 0
end
if i == 0
else
end
if i == 0
elsif i == 0
end
if i == 0
elsif i == 0
else
end


p i unless i == 0
unless i != 0 then p 'c'; p 'c'; end
unless i != 0 then p 'c' end
unless i != 0 then end
unless i != 0; p 'c'; p 'c'; end
unless i != 0; p 'c' end
unless i != 0; end
unless i != 0
end
unless i != 0
else
end

case i
when 1
  p "1"
end

case i
when 1
end

case i
when 1
  p "1"
when 2
  p "1"
end

case i
when 1
when 2
end

case i
when 1
  p "1"
when 2
  p "2"
else
  p "else"
end

case i
when 1
when 2
else
end

case
when i == 1
  p "1"
when i == 2
  p "2"
else
  p "else"
end

case
when i == 1 then p "1"
when i == 2 ; p "2"
else p "else"
end

p i == 0 ? "0" : "1"


while i != 0 do p 'c'; p 'c'; end
while i != 0 do p 'c' end
while i != 0 do end
while i != 0; p 'c' end
while i != 0; end
while i != 0
end


until i == 0 do p 'c'; p 'c'; end
until i == 0 do p 'c' end
until i == 0 do end
until i == 0; p 'c' end
until i == 0; end
until i == 0
end


for y in [] do p 'c'; p 'c'; end
for y in [] do p 'c' end
for y in [] do end
for y in []; p 'c' end
for y in []; end
for y in []
  p 'c'
end
for y in []
end


loop do p 'c'; p 'c'; end
loop do p 'c' end
loop do end
loop { p 'c'; p 'c'; }
loop { p 'c' }
loop { }


def a() p 'c'; p 'c'; end
def a() p 'c' end
def a() end


[].each { |b| p b; p b; }
[].each { |b| p b }
[].each { |b| }
[].each { }
[].each do |b| p b end
[].each do |b| end
[].each do end


lambda { |x,y| x + y }
lambda { |x,y| }
lambda { |x| x + 1 }
lambda { |x| }
lambda {}
lambda do |x| p x + 1 end
lambda do |x| end
lambda do end
