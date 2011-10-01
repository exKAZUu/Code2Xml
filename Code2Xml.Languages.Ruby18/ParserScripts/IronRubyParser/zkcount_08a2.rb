#! ruby -Ks

require 'find'
require 'jcode'
require 'fileutils'
require 'pp'
require 'Win32API'
#require 'win32ole'

#--------------------------------------------------
# CTRL-Cが押されたときの処理
#--------------------------------------------------
Signal.trap(:INT) do
  puts ""
  puts "* CTRL-Cが入力されました。"
  puts "* 処理を中断します。"
  puts ""
  exit
end 


# 引数が無い場合は，カレントディレクトリとみなすか
# エラーメッセージ（使用法表示）をするべし

def countword(target_dir, output_csv, xdoc2txt, tmpfile, del_text)
  #--------------------------------------------------
  # 準備処理
  #--------------------------------------------------
  puts("=====[ countword ]=====")
  p_param(target_dir, output_csv, xdoc2txt, tmpfile, del_text)


  #--------------------------------------------------
  # csvファイルが書き込みできない場合はエラー終了
  #--------------------------------------------------
  begin
    csv = File.open(output_csv, 'w')
  rescue
    puts ""
    puts "* csvファイルが書き込みできない状態です"
    puts "* 処理を中止します．"
    exit
  end

  csv.print("ディレクトリ名,ファイル名,文字数,場合,かつ,または,および,あるいは,且つ,又は,及び,或いは\n")

  count = Hash.new(0)

  #--------------------------------------------------
  # キーワードのカウント処理
  #--------------------------------------------------
  #puts("target_dir = "+target_dir)

  Find.find(target_dir) { |path|

    #if FileTest::directory?(path) then
    #  if (path.length > 256) then
    #      csv.print(path, ",")
    #      csv.print(path.length, ",")
    #      csv.print("【警告】パスが長すぎます。配下のファイルを測定できません。\n")
    #    next
    #  end
    #end

    #--------------------------------------------------
    # pathがファイルならば
    #--------------------------------------------------
    if FileTest::file?(path) 

      #--------------------------------------------------
      # 拡張子が doc または xls ならば (+ ppt, pdf)
      #--------------------------------------------------
      dir, base = File::split(path)
      ext = File.extname(base)

      #if ext =~ /.doc|.xls/
      #if ext =~ /.[Dd][Oo][Cc]|.[Xx][Ll][Ss]/
      if ext =~ /.[Dd][Oo][Cc]|.[Xx][Ll][Ss]|.[Pp][Pp][Tt]|.[Pp][Dd][Ff]/

      #if (path.length > 256) then
      #  csv.print(dir, ",")
      #  csv.print(base, ",")
      #  csv.print("【警告】パスが長すぎます。ファイルを測定できません。\n")
      #  next
      #end

        #--------------------------------------------------
        # テキスト化処理 (xdoc2txtの実行)
        #--------------------------------------------------
        #getTxt  = xdoc2txt + " " + path + " > " + tmpfile

        # ファイル名に空白を含む場合の考慮が必要
        getTxt  = xdoc2txt + " " + sprintf("\"%s\"", path) + " > " + tmpfile
        res = system(getTxt)

        #puts "=====[ res = system(getTxt) -> True/False]====="
        #pp res
        #puts "==================================="

        #open(path).read.scan(/場合|かつ|または|および|あるいは/){|w| count[w] += 1}

        f = open(tmpfile)
        txt = f.read
        f.close
        File.delete(tmpfile)

        # xdoc2txtの結果を保存
        if (del_text =~ /[13]/) then
          #txtfile = dir + "/" + File.basename(base, ext) + "_" + ext[1..3] + ".txt"
          txtfile = dir + "/" + File.basename(base, ext) + ".txt"

          tf = open(txtfile, 'w')
          tf.print(txt)
	      tf.close

          #if (txtfile.size <= 256) then
          #  tf = open(txtfile, 'w')
          #  tf.print(txt)
	      #  tf.close
          #end

        end

        # 空白やタブを取り除く
        txt.gsub!(/[ 　\t\n\r\f\v]+/, "")

        # WORDファイルの目次をテキスト化した場合の「ゴミ」削除
        txt.gsub!(/\x01\x14/, "_")


        txt.scan(/場合|かつ|または|および|あるいは|且つ|又は|及び|或いは/){|w| count[w] += 1}
		len = txt.jlength

        #csv.print(path, ",")
        csv.print(dir, ",")
        csv.print(base, ",")
        csv.print(len, ",")
        csv.print(count["場合"], ",")
        csv.print(count["かつ"], ",")
        csv.print(count["または"], ",")
        csv.print(count["および"], ",")
        csv.print(count["あるいは"], ",")
        csv.print(count["且つ"], ",")
        csv.print(count["又は"], ",")
        csv.print(count["及び"], ",")
        csv.print(count["或いは"], "\n")

		count.clear

        # 測定用テキストをファイルとして保存
        if (del_text =~ /[23]/) then
          #txtfile = dir + "/" + File.basename(base, ext) + "_" + ext[1..3] +  "_w.txt"
          txtfile = dir + "/" + File.basename(base, ext) + ".wrk"

          tf = open(txtfile, 'w')
          tf.print(txt)
	      tf.close

          #if (txtfile.size <= 256) then
          #  tf = open(txtfile, 'w')
          #  tf.print(txt)
	      #  tf.close
          #end

        end

        # 1,2,3 で作成したテキストファイルを削除
        if (del_text =~ /[Xx]/) then
          # 1 で作成したテキストファイル
          #txtfile = dir + "/" + File.basename(base, ext) + "_" + ext[1..3] + ".txt"
          txtfile = dir + "/" + File.basename(base, ext) + ".txt"
          if FileTest.exist?(txtfile) then
            File.delete(txtfile)
          end

          # 2 で作成したテキストファイル
          #txtfile = dir + "/" + File.basename(base, ext) + "_" + ext[1..3] + "_w.txt"
          txtfile = dir + "/" + File.basename(base, ext) + ".wrk"
          if FileTest.exist?(txtfile) then
            File.delete(txtfile)
          end

        end

      end

    end

  }

  #--------------------------------------------------
  # 後処理
  #--------------------------------------------------
  csv.close

end


#--------------------------------------------------
# パラメタの内容表示関数
#--------------------------------------------------
def p_param(target_dir, output_csv, xdoc2txt, tmpfile, del_text)
  puts("----------------------------------------")
  puts("tmpfile    = "+ tmpfile)
  puts("xdoc2txt   = "+ xdoc2txt)
  puts("target_dir = "+ target_dir)
  puts("output_csv = "+ output_csv)
  if (del_text =~ /0|1|2/) then
    puts("del_text = "+ del_text)
  end
  puts("----------------------------------------")
end

#--------------------------------------------------
# ファイルの存在チェック
#--------------------------------------------------
def file_exist(str, chkf)

  if chkf == nil then
    puts "* " + str + " " + " が指定されていません"
    exit
  end

  if FileTest.exist?(chkf) then
  else
    puts "* " + str + " " + chkf + " が存在しません"
    exit
  end
end

#--------------------------------------------------
# ファイルの上書きチェック
#--------------------------------------------------
def write_chk(str, chkf)

  if chkf == nil then
    puts "* " + str + " " + " が指定されていません"
    exit
  end

  if FileTest.exist?(chkf) then
    print "* ", str, " が存在しています\n"
    print "* 上書きしてよいですか？ (y/n)"

    #ans = STDIN.gets
    ans = get_yn

    #if ans =~ /[Yy]|[Yy][Ee][Ss]/ then
    if (ans == 'y') then
    elsif (ans == 'n') then
      puts "* 処理を中止します．"
      exit
    else
    end

  else
    #ディレクトリの存在も確認する
    dir, base = File::split(chkf)
    if FileTest.exist?(dir) then
    else
    # 存在していない場合
      print "* ", str, " (", base, ") のディレクトリ (",dir,") がありません\n"
      print "* 作成しますか？ (y/n)"
      #ans = STDIN.gets
      ans = get_yn

      #if ans =~ /[Yy]|[Yy][Ee][Ss]/ then
      if (ans == 'y') then
        if( FileUtils.mkpath(dir) ) then
          print "* ディレクトリ (",dir,") を作成しました\n\n"
        else
          print "* ディレクトリを作成できませんでした\n"
          print "* 処理を中止します．\n"
          exit
        end
      elsif (ans == 'n') then
        print "\n* 処理を中止します．\n"
        exit
      else
      end
    end
  end
end

#--------------------------------------------------
# yかnを得る
#--------------------------------------------------
def get_yn
  func_getch = Win32API.new('crtdll.dll', '_getch', 'v', 'i')
  while true do
    ch = func_getch.call.chr.downcase

    case ch
    when 'y'
      break
    when 'n'
      break
    when "\C-c"
	#getchでコンソールを奪うと中断出来ないので
	exit
    else
      #print ">> "
    end
  end
  puts ""
  return ch
end

#==================================================
# メイン処理
#==================================================
paramfile = ARGV[0]

if (ARGV.size >= 2) then
  puts  ""
  puts "【警告】引数はパラメタファイルのみ指定可能です。"
  puts "        ２番目以降の引数は無視します。"
  puts 
end

#--------------------------------------------------
# パラメタファイルの存在チェック
#--------------------------------------------------
file_exist("パラメタファイル", paramfile)

if FileTest.readable?(paramfile) then
else
  puts ""
  puts "* パラメタファイルが読取不可です"
  puts "* 処理を中断します"
  exit
end

open(paramfile) {|file|
  while line = file.gets
    # 行末の改行コードを取り除く
    #line.chop!
    # 行内の空白とタブを取り除く
    #line.gsub!(/[ \t]*/, "")

    # コメントを取り除く
    line.sub!(/#.*$/, "")

    # 行末の改行コードだけでなく，
    # 先頭と末尾の空白文字を全て取り除く
    line.strip!

    #p line

    # 空行は無視する
    if line =~ /^$/ then
      next
    end

    # 左辺，または右辺が無い場合は無視する
    if ((line =~ /^=/) or (line =~ /=$/)) then
      puts  ""
      print "* パラメタファイルの設定が正しくありません (", line, ") \n"
      print "* 設定を修正してください\n"
      exit
    end

    word = line.split(/\s*=\s*/)

    # 念のため
    word[0].strip!
    word[1].strip!

    #p word

    case word[0]
    when "tmpfile"
      tmpfile = word[1]
    when "xdoc2txt"
      xdoc2txt = word[1]
    when "target_dir"
      target_dir = word[1]
    when "output_csv"
      output_csv = word[1]
    when "del_text"
      del_text = word[1]
    else
      puts  ""
      print "【警告】パラメタファイルに不明な設定 (", word[0], ") があります。無視します。\n"
      next
    end
  end

  puts  ""

  #p_param(target_dir,output_csv,xdoc2txt,tmpfile,del_text)
  #puts "----------"
  #puts "  Main"
  #puts "----------"
  #pp tmpfile
  #pp xdoc2txt
  #pp target_dir
  #pp output_csv
  #pp del_text
  #puts "----------"

  #--------------------------------------------------
  # 入力ファイル，ディレクトリの存在チェック
  #--------------------------------------------------
  file_exist("テキスト化処理コマンド", xdoc2txt)
  file_exist("処理対象ディレクトリ", target_dir)

  #--------------------------------------------------
  # 一時ファイルと出力ファイルは，存在している場合
  # 上書き確認をしたい
  #--------------------------------------------------
  write_chk("テキスト出力用一時ファイル", tmpfile)
  write_chk("出力csvファイル", output_csv)

  #--------------------------------------------------
  # "テキスト削除フラグ"のチェック
  #--------------------------------------------------
  if del_text == nil then
    del_text = " "
  end

  # X は隠しオプション
  if (del_text =~ /^[0123Xx ]$/) then
    #puts("del_text = "+ del_text)
  else
    puts ""
    puts "* del_text" + " には 0|1|2|3 のいずれかを指定してください"
    exit
  end

  countword(target_dir, output_csv, xdoc2txt, tmpfile, del_text)
}
