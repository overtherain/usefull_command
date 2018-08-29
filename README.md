修改 apeche主页：
1、修改默认网站目录
ubuntu8.10下修改apache2的默认文档目录 默认是在/var/www里面
sudo gedit /etc/apache2/sites-enabled/000-default
 
在文档中找到 DocumentRoot 在后面修改你要放置网页文件的目录。
修改完了 别忘记重启apache2服务器
命令： sudo /etc/init.d/apache2 restart
 
2、修改默认主页
修改默认主页：一般在 sudo gedit /etc/apache2/apache2.conf里面
找到 DirectoryIndex 在后面添加 如index.php等
不过随apache2的版本不同 文件的放置位置不一样 我在ubuntu8.10下面配置文件就不一样。
 
别怕 输入这个命令 grep -iR DirectoryIndex /etc/apache2
查看 DirectoryIndex 在apache2那个文件里面。


修改文件权限

sudo chmod a+rw 777/666 /xxx/xxx/xxx 
sudo chmod a+rw -Rv /xxx/xxx/xxx



3、文件夹建立软链接（用绝对地址）

　　ln -s 源地址  目的地址

　　比如我把linux文件系统rootfs_dir软链接到/home/jyg/目录下

　　ln -s /opt/linux/rootfs_dir  /home/jyg/rootfs_dir就可以了
           文件目录              目标目录


4、删除上一个commit

方法:

    git reset --hard <commit_id>

    git push origin HEAD --force


5.安装deb包
sudo dpkg -i iptux.deb#安装iptux.deb软件包（其中-i等价于--install）

=====================================================================================================================


mmm xxx/xxx/xxx
make snod
zgd_521
870260521


make -j24 2>&1 | tee log.txt 重定向日志

 git clone git@192.168.1.9:sp7730.git

git push orige


高通编译 {
  ./cgbuild.sh

  cd ~\code\L9011A\qualcomm_8916\common\build
  python update_common_info.py

镜像文件
  ~\code\L9011A\qualcomm_8916\common\build\bin\asic\sparse_images
  ~\code\L9011A\qualcomm_8916\LINUX\android\out\target\product\msm8916_32_512
}


fastboot 烧录 {

  adb reboot devices
  adb reboot bootloader
  fastboot devices
  cd D:\dl9011\dl\s
  fastboot flash boot boot.img
  fastboot flash recovery recovery.img
  fastboot flash system system.img
}

git log --graph 树形显示log

git log --name-status 显示log的状态

vim /home/zhangshaobin/.bashrc 终端配置

vim /home/zhangshaobin/.bash_history 命令历史记录

history 命令记录输出




awk
xargs
|
vim{
: 进入命令行模式
:%s/src/dest/g dest替换src
:%s/src/dest/
自动补齐 ctrl+p 仅限于当前文件已经使用过的，或者结合ctags实现函数跳转
}

获取patch文件: {
git log --graph --name-status
git show 6764d5e40c87a9e2642f7be622c0130c37db1d61 > name.diff 制作patch diff包

cat name.diff | grep diff | awk '{print $4}' > tt
vi tt 删除路径前的a/b
cat tt | xargs tar -cavf name.tar.gz 把tt内的文件打包
tar -cavf name.tar.gz `cat tt`
}

*#*#837866#*#* 查版本号
*#*#837868#*#* 查量产版本日期
*#*#83789#*#*  工厂测试
*#*#83781#*#*  工程模式

LOG
1，程序异常退出，uncausedexception      (Fatal)
2，程序强制关闭，ForceClosed (简称FC)   (Fatal)
3，程序无响应，  ApplicationNo Response (ANR)
                 Caused by
 
 
find命令
find frameworks/ -name AudioPolicyManagerBase.cpp
find 路径 -name 文件名
						

git commit --amend修改commit 信息	

git revert commitid  回退提交的某次记录

ifconfig ubuntu 查询ip
 
MTK EngineerMode *#*#3646633#*#*

git log 查看提交的id
git format-patch xxxxxxxxxxxxx(commit id)

getprop ro.product.partitionpath adb获取ro路径

git cherry-pick commit-id 从其他分支合入commit修改

git diff --cached > tmp.diff

压缩命令

tar -cvf /tmp/etc.tar /etc  <==仅打包，不压缩！

tar -czvf /tmp/etc.tar.gz /etc  <==打包后，以 gzip 压缩

tar -cjvf /tmp/etc.tar.bz2 /etc  <==打包后，以 bzip2 压缩

解压
tar -xzvf /tmp/etc.tar.gz

卫星信号
*#*#2266#*#*


1.将当前目录下所有.txt文件打包并压缩归档到文件this.tar.gz，我们可以使用
tar czvf this.tar.gz ./*.txt

2.将当前目录下的this.tar.gz中的文件解压到当前目录我们可以使用
tar xzvf this.tar.gz ./

ubuntu 个人文件夹 中文转英文
export LANG=en_US
xdg-user-dirs-gtk-update

设置ubuntu 编译环境
###################BEGIN###########################
1、安装Android5.1环境编译需要的相关包

sudo apt-get install git-core gnupg flex bison gperf build-essential zip curl zlib1g-dev libc6-dev lib32ncurses5-dev lib32z1 x11proto-core-dev libx11-dev  lib32z1-dev libgl1-mesa-dev g++-multilib mingw32 tofrodos python-markdown libxml2-utils xsltproc  lib32readline-gplv2-dev

2、安装openJDK

sudo apt-get install default-jre

sudo apt-get install default-jdk

默认安装在usr/lib/jvm下，安装成功了，可以通过java -version进行查看，如要设为默认的，可进行如下步骤 

sudo update-alternatives --install /usr/bin/java java /usr/lib/jvm/java-1.7.0-openjdk-amd64/bin/java 300
sudo update-alternatives --install /usr/bin/javac javac /usr/lib/jvm/java-1.7.0-openjdk-amd64/bin/javac 300
sudo update-alternatives --config java

设置环境变量（全局）

sudo gedit  /etc/profile

export JAVA_HOME=/usr/lib/jvm/java-1.7.0-openjdk-amd64</span>
export CLASSPATH=".:$JAVA_HOME/lib:$CLASSPATH"
export PATH="$JAVA_HOME/bin:$PATH"

sudo gedit /etc/environment添加相应的path路径
####################END##############################

MAC 禁用dashboard 
defaults write com.apple.dashboard mcx-disabled -boolean YES && killall Dock

#########################################################
#############ubuntu 配置 git 服务器 #########################
1.安装git ssh gitolite
2.创建git库账户 sudo adduser --system --group --shell /bin/bash git
3.创建git-admin管理账户的ssh-keygen，并将公钥scp至git账户。
4.在git账户用git-admin的ssh-key初始化 gl-setup xxx.pub
5.在git-admin账户clone管理分支 git clone git@xxx.xxx.xxx.xxx:gitolite-admin
  5.1 该项目有两个文件夹conf keydir
  5.2 权限设置：conf/gitolite.conf
  5.3 项目添加：
      5.3.1 修改gitolite.conf 添加repo，拷贝pubkey至keydir, git add . && git push origin master
      5.3.2 mkdir xxx，git init，git remote add origin master git@xxx.xxx.xxx.xxx:xxx.git，git push origin master
  5.4 添加用户：
      5.4.1 sudo adduser xxxx
      5.4.2 passwd xxxx
      5.4.3 登入su - xxxx，生成秘钥 ssh-keygen -t rsa -C ""
      5.4.4 将秘钥拷贝到git-admin用户下,提交gitolite-admin

6.添加git库
  6.1 用gitadmin账户修改gitolite-admin/config/gitolite.config,添加
       repo    proja
             RW+    =[user]
       repo    projb
             RW+    =@group
             @group =[user1] [user2] ...
  6.2 用gitadmin账户add,commit,push
  
7.安装gitweb
  7.1 sudo apt-get install gitweb hightlight
  7.2 在目录/etc/apache2/sites-available/ 创建gitweb.conf
       <Directory "/usr/share/gitweb">
            Options +FollowSymLinks +ExecCGI
            AddHandler cgi-script .cgi
            DirectoryIndex gitweb.cgi index.cgi
            Order allow,deny
            Allow from all
        </Directory>
  7.3 修改/etc/gitweb.conf中的$projectroot
  7.4 如过localhost/gitweb.cgi不显示项目,需修改项目权限为755
      
#########################################################

ubuntu vi编辑模式，backspace，上，下，左，右，无效的解决方法
1.重新安装VIM
2.在.bashrc中添加
   set nocompatible
   set backspace=2 
   
SSH免登陆服务器配置
 1.server端在~/.ssh/目录创建authorized_keys文件，设置权限600
 2.user端ssh-keygen -t rsa -C "mail"生成key，将pub key 用 scp xxx.pub server@xxx.xxx.xxx.xxx:.ssh/至服务端
 3.user端在~/.ssh/配置config文件
         Host xxx.xxx.xxx.xxx
		 HostName xxx.xxx.xxx.xxx
		 User          xxx
		 IdentityFile  ~/.ssh/xxx    （此处为私钥）
 4.known_hosts内保存的为server地址
 
给用户添加root权限
   修改/etc/group 

从.git创建git初始仓库
git clone --bare -l /home/proj/.git /pub/scm/proj.git


修改ubuntu ip:修改/etc/network/interfaces
 添加固定ip:
 auto eth0
 iface eth0 inet static
 address xxx.xxx.xxx.xxx
 netmask 255.255.255.0
 gateway xxx.xxx.xxx.xxx

修改ubuntu 系统语言
 修改/etc/default/locale
  LANG="en_US.UTF-8"
  LANGUAGE="en_US:en"

 locale-gen -en_US:en

 中文可安装 sudo apt-get install zhcon

###########################################################
######## 配置samba服务 ###############
安装samba
 sudo apt-get install samba smbfs

 sudo useradd [myname]
 sudo passwd [myname]

 sudo touch /etc/samba/smbpasswd
 sudo smbpasswd -a [myname] 新增
 sudo smbpasswd -x [myname] 删除

新增网络使用者的帐号：
　sudo gedit /etc/samba/smbusers
 [myname]= "networkusername"

修改/etc/samba/smb.conf
添加
[share]
   comment = Ubuntu File Server Share
   path = /home/share
   available = yes
   browseable = yes
   guest ok = yes
   read only = no
   public = yes
   writable = yes

;  valid users = [myname]
   create mask = 0755
   directory mask =0755
   force user =nobody
   force group = nogroup

修改workgroup
  workgroup = [workgroup](用户组)
　　display charset = UTF-8
　　unix charset = UTF-8
　　dos charset = cp936
 
保存并关闭配置文件，在终端中输入如下命令
sudo testparm
重新启动服务
sudo /etc/init.d/samba restart

查看磁盘大小
df -hl
du -sm
下面是相关命令的解释：
df -hl 查看磁盘剩余空间
df -h 查看每个根路径的分区大小
du -sh [目录名] 返回该目录的大小
du -sm [文件夹] 返回该文件夹总M数
更多功能可以输入一下命令查看：
df --help
du --help

**************************************************
**
**   [root@bsso yayu]# du -h --max-depth=1 work/testing  
**   27M     work/testing/logs  
**   35M     work/testing  
**     
**   [root@bsso yayu]# du -h --max-depth=1 work/testing/*  
**   8.0K    work/testing/func.php  
**   27M     work/testing/logs  
**   8.1M    work/testing/nohup.out  
**   8.0K    work/testing/testing_c.php  
**   12K     work/testing/testing_func_reg.php  
**   8.0K    work/testing/testing_get.php  
**   8.0K    work/testing/testing_g.php  
**   8.0K    work/testing/var.php  
**     
**   [root@bsso yayu]# du -h --max-depth=1 work/testing/logs/  
**   27M     work/testing/logs/  
**     
**   [root@bsso yayu]# du -h --max-depth=1 work/testing/logs/*  
**   24K     work/testing/logs/errdate.log_show.log  
**   8.0K    work/testing/logs/pertime_show.log  
**   27M     work/testing/logs/show.log  
**
**************************************************

安装流媒体服务Darwin Streaming Server
下载软件http://dss.macosforge.org/downloads/DarwinStreamingSrvr5.5.5-Linux.tar.gz
修改

if [ $INSTALL_OS = "Linux" ]; then  
/usr/sbin/useradd -M qtss > /dev/null 2>&1  
else  
/usr/sbin/useradd qtss > /dev/null 2>&1  
fi
将-M修改成-m
streamingadminserver.pl运行服务
http://127.0.0.1:1220 管理
rtsp://127.0.0.1/sample_100kbit.mp4
DSS 支持的视频文件需要特别的工具对视频 hint 一下，然后就可以在 RTSP 上面用，请下载 mp4box http://www.videohelp.com/tools/mp4box 使用，mp4box同时支持mp4和3gp。
下载到到解压出后会有个叫 mp4box.exe ，用它在命令行下面运行
C:\mp4box sample.mp4 -hint

ubuntu 安装mp4box
git clone https://github.com/gpac/gpac.git
cd gpac
git pull
./configure --static-mp4box --use-zlib=no
make -j4
sudo make install

查进程
ps aux | grep -i xxx
查端口
sudo netstat -ntulp | grep xxx

vs2010代码格式化快捷键ctrl+k,f 引用alt+.

windows 拷贝命令
xcopy /e /y C:\Users\Administrator\Documents F:\Save
del/e/q C:\Users\Administrator\Documents\xxx.xxx


selinux 权限问题
查看kerner log
adb shell
cat /proc/kmsg | grep "avc"
例:scontext=u:r:system_app:s0 tcontext=u:object_r:media_data_file:s0 tclass=dir permissive=0 
    system_app   media_data_file   dir   
修改/external/sepolicy/下文件
system_app.te
添加allow system_app media_data_file:dir open;

Git将本地仓库上传到远程仓库:
    1.本地创建项目xxx git init初始化
    2.远程创建项目xxx git --bare init初始化
    3.git remote add origin git://x.x.x.x/xxx.git
    4.git push origin master


windows映射远程盘符到本地盘符
    e.g. net use Y: \\192.168.10.2\zhangshaobin 123123 /user:zhangshaobin
    

netsh wlan start hostednetwork


vmliux（out\target\product\sp9832a_3h10_volte\obj\KERNEL\vmliux）


git push --tags 将tag push到远程仓库

==============================================================================
android 7.0 编译
编译办法:
比如说编译sp7731c_1h10_32v4_native-user
执行如下命令:
source build/envsetup.sh
lunch sp7731c_1h10_32v4_native-user
kheader
IDH_PROP_ZIP=<oprietories-sp7731c_1h10_32v4_native-user.zip的路径> make -jN

IDH_PROP_ZIP=proprietories-sp9832a_2h11_4mvoltesea_tee-user.zip  make -j32
==============================================================================

360 查看apk版本路径

adb shell "dumpsys package com.qiku.music | grep -rn versionName"

修改MySQL varchar类型字段的排序规则

SELECT CONCAT('ALTER TABLE `', table_name, '` MODIFY `', column_name, '` ', DATA_TYPE, '(', CHARACTER_MAXIMUM_LENGTH, ') CHARACTER SET UTF8 COLLATE utf8_unicode_ci', (CASE WHEN IS_NULLABLE = 'NO' THEN ' NOT NULL' ELSE '' END), ';')
FROM information_schema.COLUMNS
WHERE TABLE_SCHEMA = 'db_dfsl'
AND DATA_TYPE = 'varchar'
AND
(
    CHARACTER_SET_NAME != 'utf8'
    OR
    COLLATION_NAME != 'utf8_unicode_ci'
);

database需要改成实际数据库名字


服务器远程
192.168.10.201   dfsl123123

编译去掉OTA编译

diff --git a/alps/build/core/main.mk b/alps/build/core/main.mk
index 6d1c8a3..168dd27 100755
--- a/alps/build/core/main.mk
+++ b/alps/build/core/main.mk
@@ -964,8 +964,7 @@ droidcore: files \
        $(INSTALLED_CACHEIMAGE_TARGET) \
        $(INSTALLED_VENDORIMAGE_TARGET) \
        $(INSTALLED_FILES_FILE) \
-       $(INSTALLED_FILES_FILE_VENDOR) \
-       $(BUILT_TARGET_FILES_PACKAGE)
+       $(INSTALLED_FILES_FILE_VENDOR)
 # 360OS end


备份ubuntu系统:
sudo tar -cvpzf sysbackup.tgz --exclude=/proc --exclude=/lost+found --exclude=/home/code/sysbackup.tgz --exclude=/home/code/repositories_20180416.tgz --exclude=/mnt --exclude=/repositories --exclude=/sys --exclude=/media /

    tar 是用来备份的程序
    c - 新建一个备份文档
    v - 详细模式， tar程序将在屏幕上实时输出所有信息。
    p - 保存许可，并应用到所有文件。
    z - 采用‘gzip’压缩备份文件，以减小备份文件体积。
    f - 说明备份文件存放的路径， Ubuntu.tgz 是本例子中备份文件名。
    “/”是我们要备份的目录，在这里是整个文件系统。
    在档案文件名“backup.tgz”和要备份的目录名“/”之间给出了备份时必须排除在外的目录。有些目录是无用的，例如“/proc”、“/lost+ found”、“/sys”。当然，“backup.tgz”这个档案文件本身必须排除在外，否则你可能会得到一些超出常理的结果。如果不把“/mnt”排除在外，那么挂载在“/mnt”上的其它分区也会被备份。另外需要确认一下“/media”上没有挂载任何东西(例如光盘、移动硬盘)，如果有挂载东西， 必须把“/media”也排除在外.
    备份完成后，在文件系统的根目录将生成一个名为“backup.tgz”的文件，它的尺寸有可能非常大。现在你可以把它烧录到DVD上或者放到你认为安全的地方去。 
    在备份命令结束时你可能会看到这样一个提示：’tar: Error exit delayed from previous errors’，多数情况下你可以忽略它。

恢复ubuntu系统:
    如果原来的Ubuntu系统已经崩溃，无法进入。则可以使用Ubuntu安装U盘（live USB）进入试用Ubuntu界面。

    切换到root用户，找到之前Ubuntu系统的根目录所在磁盘分区（一般电脑上的磁盘分区（假设分区名称为sdaX）均可以在当前Ubuntu系统的根目录下的media目录下（即/media）找到。目录通常为当前根目录下 cd /media/磁盘名称/分区名称）。进入该分区，输入以下指令来删除该根目录下的所有文件： 
    $ sudo rm -rf /media/磁盘名称/分区名称*

    将备份文件”backup.tgz”拷入该分区； 
    $ sudo cp -i backup.tgz /media/磁盘名/分区名sdaX

    进入分区并将压缩文件解压缩，参数x是告诉tar程序解压缩备份文件。 
    $ sudo tar -xvpfz backup.tgz

    重新创建那些在备份时被排除在外的目录； 
    $ sudo mkdir proc lost+found mnt sys media 
    或者这样： 
    mkdir proc 
    mkdir lost+found 
    mkdir mnt 
    mkdir sys
    
    
数据库备份/恢复命令
mysqldump -h localhost -uroot -p databasename > ./backupfile.sql   备份
mysql -h localhost -uroot -p databasename < backupfile.sql 恢复


备份MySQL数据库的命令


mysqldump -hhostname -uusername -ppassword databasename > backupfile.sql
备份MySQL数据库为带删除表的格式
备份MySQL数据库为带删除表的格式，能够让该备份覆盖已有数据库而不需要手动删除原有数据库。


mysqldump -–add-drop-table -uusername -ppassword databasename > backupfile.sql
直接将MySQL数据库压缩备份


mysqldump -hhostname -uusername -ppassword databasename | gzip > backupfile.sql.gz
备份MySQL数据库某个(些)表


mysqldump -hhostname -uusername -ppassword databasename specific_table1 specific_table2 > backupfile.sql
同时备份多个MySQL数据库


mysqldump -hhostname -uusername -ppassword –databases databasename1 databasename2 databasename3 > multibackupfile.sql
仅仅备份数据库结构


mysqldump –no-data –databases databasename1 databasename2 databasename3 > structurebackupfile.sql
备份服务器上所有数据库


mysqldump –all-databases > allbackupfile.sql
还原MySQL数据库的命令


mysql -hhostname -uusername -ppassword databasename < backupfile.sql
还原压缩的MySQL数据库


gunzip < backupfile.sql.gz | mysql -uusername -ppassword databasename
将数据库转移到新服务器


mysqldump -uusername -ppassword databasename | mysql –host=*.*.*.* -C databasename



gerrit git review默认配置

apt-get install git-review

vi /etc/git-review/git-review.conf

[updates]
check = false
[gerrit]
host = 192.168.10.3
port = 29418
defaultbranch = master
defaultremote = origin



