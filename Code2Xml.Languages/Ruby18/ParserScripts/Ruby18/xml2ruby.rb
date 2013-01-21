$LOAD_PATH.push('ParserScripts/Ruby18')
require 'ruby2ruby'
require 'rexml/document'

#class Ruby2Ruby
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
#end

def traverse_xml(elem)
  arr = Sexp.new(elem.name.to_sym)
  for e in elem.elements
    arr << terminal_node2array_element(e)
  end
  arr
end

def terminal_node2array_element(elem)
  case elem.name
  when 'nil'
    nil
  when 'Symbol'
    elem.text.to_sym
  when 'String'
    elem.text
  when 'Fixnum'
    elem.text.to_i
  when 'Bignum'
    elem.text.to_i
  when 'Float'
    elem.text.to_f
  else
    traverse_xml(elem)
  end
end

doc = REXML::Document.new($stdin)
print Ruby2Ruby.new.process(traverse_xml(doc.root))
