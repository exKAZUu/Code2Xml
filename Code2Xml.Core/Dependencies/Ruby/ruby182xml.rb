# encoding: UTF-8

$LOAD_PATH.push('Dependencies/Ruby')
require 'ruby_parser'
require 'print_ast'

STDIN.set_encoding("UTF-8", "UTF-8")
STDOUT.set_encoding("UTF-8", "UTF-8")

s = Ruby18Parser.new.parse(STDIN.read)
print_ast(s)
