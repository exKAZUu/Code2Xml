def set_pixel(h)
  # キーワード引数はシンボルがキーのハッシュとして受け取る
  @field[h[:y]][h[:x]] = h[:color]
end

# 呼び出しはキーワード引数風に
set_pixel(x:30, y:50, color:"red")
set_pixel(color:"black", x:40, y:50)

def foo(a, b, *ary, z)
  p [a, b, ary, z]
end

def foo(a, b, c, d)
  p [a, b, c, d]
end

ary = [1, 2]

foo(*ary, *ary)

foo(1, 2, 3, 4, 5)

add_1 = ->(x) { x + 1 }
p add_1.(42)
