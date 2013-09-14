# encoding: UTF-8

$LOAD_PATH.push('ParserScripts/Ruby19')
require 'ruby_parser'

def traverse(exp)
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

STDIN.set_encoding("UTF-8", "UTF-8")
STDOUT.set_encoding("UTF-8", "UTF-8")

s = Ruby19Parser.new.parse(STDIN.read)
print traverse(s)
