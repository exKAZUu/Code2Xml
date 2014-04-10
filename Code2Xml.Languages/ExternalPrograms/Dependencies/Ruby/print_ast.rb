# encoding: UTF-8

def print_bool(val)
  print(val ? '1' : '0')
end

def print_int(val)
  print(val.to_s + ',')
end

def print_string(str)
  print_int(str.length)
  print(str) 
end

def print_ast(exp)
  name = exp[0]
  print "<#{name} startline='#{exp.line}'>"
  exp[1..-1].each_with_index do |t, i|
    case t
    when Sexp
      traverse(t)
    when nil
      print "<nil/>"
    else
      v = t.to_s
      v.gsub!("&", "&amp;")
      v.gsub!("<", "&lt;")
      v.gsub!(">", "&gt;")
      print "<#{t.class}>#{v}</#{t.class}>"
    end
  end
  print "</#{name}>"
end
