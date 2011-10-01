#! ruby -Ks

require 'find'
require 'jcode'
require 'fileutils'
require 'pp'
require 'Win32API'
#require 'win32ole'

#--------------------------------------------------
# CTRL-C�������ꂽ�Ƃ��̏���
#--------------------------------------------------
Signal.trap(:INT) do
  puts ""
  puts "* CTRL-C�����͂���܂����B"
  puts "* �����𒆒f���܂��B"
  puts ""
  exit
end 


# �����������ꍇ�́C�J�����g�f�B���N�g���Ƃ݂Ȃ���
# �G���[���b�Z�[�W�i�g�p�@�\���j������ׂ�

def countword(target_dir, output_csv, xdoc2txt, tmpfile, del_text)
  #--------------------------------------------------
  # ��������
  #--------------------------------------------------
  puts("=====[ countword ]=====")
  p_param(target_dir, output_csv, xdoc2txt, tmpfile, del_text)


  #--------------------------------------------------
  # csv�t�@�C�����������݂ł��Ȃ��ꍇ�̓G���[�I��
  #--------------------------------------------------
  begin
    csv = File.open(output_csv, 'w')
  rescue
    puts ""
    puts "* csv�t�@�C�����������݂ł��Ȃ���Ԃł�"
    puts "* �����𒆎~���܂��D"
    exit
  end

  csv.print("�f�B���N�g����,�t�@�C����,������,�ꍇ,����,�܂���,�����,���邢��,����,����,�y��,������\n")

  count = Hash.new(0)

  #--------------------------------------------------
  # �L�[���[�h�̃J�E���g����
  #--------------------------------------------------
  #puts("target_dir = "+target_dir)

  Find.find(target_dir) { |path|

    #if FileTest::directory?(path) then
    #  if (path.length > 256) then
    #      csv.print(path, ",")
    #      csv.print(path.length, ",")
    #      csv.print("�y�x���z�p�X���������܂��B�z���̃t�@�C���𑪒�ł��܂���B\n")
    #    next
    #  end
    #end

    #--------------------------------------------------
    # path���t�@�C���Ȃ��
    #--------------------------------------------------
    if FileTest::file?(path) 

      #--------------------------------------------------
      # �g���q�� doc �܂��� xls �Ȃ�� (+ ppt, pdf)
      #--------------------------------------------------
      dir, base = File::split(path)
      ext = File.extname(base)

      #if ext =~ /.doc|.xls/
      #if ext =~ /.[Dd][Oo][Cc]|.[Xx][Ll][Ss]/
      if ext =~ /.[Dd][Oo][Cc]|.[Xx][Ll][Ss]|.[Pp][Pp][Tt]|.[Pp][Dd][Ff]/

      #if (path.length > 256) then
      #  csv.print(dir, ",")
      #  csv.print(base, ",")
      #  csv.print("�y�x���z�p�X���������܂��B�t�@�C���𑪒�ł��܂���B\n")
      #  next
      #end

        #--------------------------------------------------
        # �e�L�X�g������ (xdoc2txt�̎��s)
        #--------------------------------------------------
        #getTxt  = xdoc2txt + " " + path + " > " + tmpfile

        # �t�@�C�����ɋ󔒂��܂ޏꍇ�̍l�����K�v
        getTxt  = xdoc2txt + " " + sprintf("\"%s\"", path) + " > " + tmpfile
        res = system(getTxt)

        #puts "=====[ res = system(getTxt) -> True/False]====="
        #pp res
        #puts "==================================="

        #open(path).read.scan(/�ꍇ|����|�܂���|�����|���邢��/){|w| count[w] += 1}

        f = open(tmpfile)
        txt = f.read
        f.close
        File.delete(tmpfile)

        # xdoc2txt�̌��ʂ�ۑ�
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

        # �󔒂�^�u����菜��
        txt.gsub!(/[ �@\t\n\r\f\v]+/, "")

        # WORD�t�@�C���̖ڎ����e�L�X�g�������ꍇ�́u�S�~�v�폜
        txt.gsub!(/\x01\x14/, "_")


        txt.scan(/�ꍇ|����|�܂���|�����|���邢��|����|����|�y��|������/){|w| count[w] += 1}
		len = txt.jlength

        #csv.print(path, ",")
        csv.print(dir, ",")
        csv.print(base, ",")
        csv.print(len, ",")
        csv.print(count["�ꍇ"], ",")
        csv.print(count["����"], ",")
        csv.print(count["�܂���"], ",")
        csv.print(count["�����"], ",")
        csv.print(count["���邢��"], ",")
        csv.print(count["����"], ",")
        csv.print(count["����"], ",")
        csv.print(count["�y��"], ",")
        csv.print(count["������"], "\n")

		count.clear

        # ����p�e�L�X�g���t�@�C���Ƃ��ĕۑ�
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

        # 1,2,3 �ō쐬�����e�L�X�g�t�@�C�����폜
        if (del_text =~ /[Xx]/) then
          # 1 �ō쐬�����e�L�X�g�t�@�C��
          #txtfile = dir + "/" + File.basename(base, ext) + "_" + ext[1..3] + ".txt"
          txtfile = dir + "/" + File.basename(base, ext) + ".txt"
          if FileTest.exist?(txtfile) then
            File.delete(txtfile)
          end

          # 2 �ō쐬�����e�L�X�g�t�@�C��
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
  # �㏈��
  #--------------------------------------------------
  csv.close

end


#--------------------------------------------------
# �p�����^�̓��e�\���֐�
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
# �t�@�C���̑��݃`�F�b�N
#--------------------------------------------------
def file_exist(str, chkf)

  if chkf == nil then
    puts "* " + str + " " + " ���w�肳��Ă��܂���"
    exit
  end

  if FileTest.exist?(chkf) then
  else
    puts "* " + str + " " + chkf + " �����݂��܂���"
    exit
  end
end

#--------------------------------------------------
# �t�@�C���̏㏑���`�F�b�N
#--------------------------------------------------
def write_chk(str, chkf)

  if chkf == nil then
    puts "* " + str + " " + " ���w�肳��Ă��܂���"
    exit
  end

  if FileTest.exist?(chkf) then
    print "* ", str, " �����݂��Ă��܂�\n"
    print "* �㏑�����Ă悢�ł����H (y/n)"

    #ans = STDIN.gets
    ans = get_yn

    #if ans =~ /[Yy]|[Yy][Ee][Ss]/ then
    if (ans == 'y') then
    elsif (ans == 'n') then
      puts "* �����𒆎~���܂��D"
      exit
    else
    end

  else
    #�f�B���N�g���̑��݂��m�F����
    dir, base = File::split(chkf)
    if FileTest.exist?(dir) then
    else
    # ���݂��Ă��Ȃ��ꍇ
      print "* ", str, " (", base, ") �̃f�B���N�g�� (",dir,") ������܂���\n"
      print "* �쐬���܂����H (y/n)"
      #ans = STDIN.gets
      ans = get_yn

      #if ans =~ /[Yy]|[Yy][Ee][Ss]/ then
      if (ans == 'y') then
        if( FileUtils.mkpath(dir) ) then
          print "* �f�B���N�g�� (",dir,") ���쐬���܂���\n\n"
        else
          print "* �f�B���N�g�����쐬�ł��܂���ł���\n"
          print "* �����𒆎~���܂��D\n"
          exit
        end
      elsif (ans == 'n') then
        print "\n* �����𒆎~���܂��D\n"
        exit
      else
      end
    end
  end
end

#--------------------------------------------------
# y��n�𓾂�
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
	#getch�ŃR���\�[����D���ƒ��f�o���Ȃ��̂�
	exit
    else
      #print ">> "
    end
  end
  puts ""
  return ch
end

#==================================================
# ���C������
#==================================================
paramfile = ARGV[0]

if (ARGV.size >= 2) then
  puts  ""
  puts "�y�x���z�����̓p�����^�t�@�C���̂ݎw��\�ł��B"
  puts "        �Q�Ԗڈȍ~�̈����͖������܂��B"
  puts 
end

#--------------------------------------------------
# �p�����^�t�@�C���̑��݃`�F�b�N
#--------------------------------------------------
file_exist("�p�����^�t�@�C��", paramfile)

if FileTest.readable?(paramfile) then
else
  puts ""
  puts "* �p�����^�t�@�C�����ǎ�s�ł�"
  puts "* �����𒆒f���܂�"
  exit
end

open(paramfile) {|file|
  while line = file.gets
    # �s���̉��s�R�[�h����菜��
    #line.chop!
    # �s���̋󔒂ƃ^�u����菜��
    #line.gsub!(/[ \t]*/, "")

    # �R�����g����菜��
    line.sub!(/#.*$/, "")

    # �s���̉��s�R�[�h�����łȂ��C
    # �擪�Ɩ����̋󔒕�����S�Ď�菜��
    line.strip!

    #p line

    # ��s�͖�������
    if line =~ /^$/ then
      next
    end

    # ���ӁC�܂��͉E�ӂ������ꍇ�͖�������
    if ((line =~ /^=/) or (line =~ /=$/)) then
      puts  ""
      print "* �p�����^�t�@�C���̐ݒ肪����������܂��� (", line, ") \n"
      print "* �ݒ���C�����Ă�������\n"
      exit
    end

    word = line.split(/\s*=\s*/)

    # �O�̂���
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
      print "�y�x���z�p�����^�t�@�C���ɕs���Ȑݒ� (", word[0], ") ������܂��B�������܂��B\n"
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
  # ���̓t�@�C���C�f�B���N�g���̑��݃`�F�b�N
  #--------------------------------------------------
  file_exist("�e�L�X�g�������R�}���h", xdoc2txt)
  file_exist("�����Ώۃf�B���N�g��", target_dir)

  #--------------------------------------------------
  # �ꎞ�t�@�C���Əo�̓t�@�C���́C���݂��Ă���ꍇ
  # �㏑���m�F��������
  #--------------------------------------------------
  write_chk("�e�L�X�g�o�͗p�ꎞ�t�@�C��", tmpfile)
  write_chk("�o��csv�t�@�C��", output_csv)

  #--------------------------------------------------
  # "�e�L�X�g�폜�t���O"�̃`�F�b�N
  #--------------------------------------------------
  if del_text == nil then
    del_text = " "
  end

  # X �͉B���I�v�V����
  if (del_text =~ /^[0123Xx ]$/) then
    #puts("del_text = "+ del_text)
  else
    puts ""
    puts "* del_text" + " �ɂ� 0|1|2|3 �̂����ꂩ���w�肵�Ă�������"
    exit
  end

  countword(target_dir, output_csv, xdoc2txt, tmpfile, del_text)
}
