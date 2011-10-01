i = 0

if i == 0 then
  p 'test'
end
unless i != 0 then
  p 'test'
end

case i
when 0
  p "test"
end

while i != 0 do
  p 'test'
end

until i == 0 do
  p 'test'
end

for y in [] do
  p 'test'
end

loop do
  p 'test'
end

loop {
  p 'test'
}

[].each do |b|
  p 'test'
end

[].each { |b|
  p 'test'
}

lambda do |x|
  p 'test'
end

lambda { |x|
  p 'test'
}
