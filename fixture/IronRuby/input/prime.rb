def prime_table(max)
	result = Array.new(max + 1, true)
	result[0] = result[1] = false
	(2..Math::sqrt(max).ceil).each { |i|
		next unless result[i]
		(i*2).step(max, i) { |j|
			result[j] = false
		}
	}
	result
end

def prime_list(table)
	result = []
	table.each_with_index { |b, i|
		result << i if b
	}
	result
end

def prime_check_table(min, max, primes)
	result = Array.new(max - min + 1, true)
	result[0] = false if min == 1
	maxsq = Math::sqrt(max).ceil
	i = 1
	while (p = primes[i]) <= maxsq
		(min + p - 1 - (min + p - 1) % p).step(max, p) { |j|
			result[j - min] = false
		}
		i += 1
	end
	return result
end

def show_primes(min, offset, max, table)
	while min <= max
		puts min + offset if table[min]
		min += 2
	end
end

if __FILE__ == $0
	max_prime = 50000
	table = prime_table(max_prime)
	primes = prime_list(table)
	primes << 1000000000 # sentry

	gets.chomp.to_i.times { |i|
		puts unless i == 0
		min, max = gets.split.map { |s| s.to_i }
		puts 2 if min <= 2

		min += 1 if min & 1 == 0
		max -= 1 if max & 1 == 0

		if max <= max_prime
			show_primes(min, 0, max, table)
		else
			if min <= max_prime
				show_primes(min, 0, max_prime, table)
				min = max_prime + 1
				min += 1 if min & 1 == 0
			end
			result = prime_check_table(min, max, primes)
			show_primes(0, min, max - min, result)
		end
	}
end

x = 1
case x
when 1
	p "1"
when 2
	p "2"
else
	p "else"
end

x == 1 ? "a" : "b"

while x >= 0 do p "a"; p "a"; end
while x >= 0 do p "a" end

until x < 0 do
  p "a"
end

for y in [] do
  p 'c'
end

def a()
  p 'c'
end

[].each { |b|
  p b
}

[].each do |b| 
  p b
end

