class A
  def a
  end
end

module B
  def b
  end
end

class C
  module CC
    def cc
    end
  end
end

class << C
  def c
  end
end

class << C.new
  def c2
  end
end

c3 = C.new
class << c3
end

def z
end
