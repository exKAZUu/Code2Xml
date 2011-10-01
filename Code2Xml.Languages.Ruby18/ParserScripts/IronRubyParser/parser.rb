require 'ruby_parser'
require 'ruby2ruby'
require 'System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'

include System::Xml::Linq

class Ruby2Ruby
  def process_block(exp)
    #return [] if exp.empty?

    result = []

    exp << nil if exp.empty?
    until exp.empty? do
      code = exp.shift
      if code.nil? or code.first == :nil then
        result << 'nil'   # modified!
      else
        result << process(code)
      end
    end

    result = result.join "\n"

    result = case self.context[1]
             when nil, :scope, :if, :iter, :resbody, :when, :while then
               result + "\n"
             else
               "(#{result})"
             end

    return result
  end
end

@r2r = Ruby2Ruby.new

def parse_code(text)
  ret = XDocument.new
  traverse(ret, RubyParser.new.parse(text.to_s.force_encoding('ascii-8bit')))
  ret.root
end

def traverse(parent, exp)
  elem = XElement.new(XName.get(exp[0].to_s))
  elem.set_attribute_value(XName.get('startline'), exp.line)
  parent.add(elem)
  
  exp[1..-1].each_with_index do |t, i|
    case t
    when Sexp
      traverse(elem, t)
    when nil
      elem.add(XElement.new(XName.get('nil')))
    else
      elem.add(XElement.new(XName.get(t.class.to_s),
        System::Text::Encoding.UTF8.GetString(t.to_s.ToByteArray)))
    end
  end
end

def parse_xml(root)
  System::Text::Encoding.UTF8.GetString(
    @r2r.process(traverse_xml(root)).ToByteArray)
end

def traverse_xml(elem)
  arr = [elem.name.local_name.to_sym]
  for e in elem.elements
    arr << terminal_node2array_element(e)
  end
  arr
end

def terminal_node2array_element(elem)
  case elem.name.local_name
  when 'nil'
    nil
  when 'Symbol'
    elem.value.to_sym
  when 'String'
    elem.value.to_s.force_encoding('ascii-8bit')
  when 'Fixnum'
    elem.value.to_i
  when 'Bignum'
    elem.value.to_i
  when 'Float'
    elem.value.to_f
  else
    traverse_xml(elem)
  end
end
