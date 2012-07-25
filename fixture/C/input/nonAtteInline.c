# 1 "quicksort.c"
# 1 "<built-in>"
# 1 "<command-line>"
# 1 "quicksort.c"
# 1 "/usr/include/stdio.h" 1 3 4
# 29 "/usr/include/stdio.h" 3 4
# 1 "/usr/include/_ansi.h" 1 3 4
# 15 "/usr/include/_ansi.h" 3 4
# 1 "/usr/include/newlib.h" 1 3 4
# 16 "/usr/include/_ansi.h" 2 3 4
# 1 "/usr/include/sys/config.h" 1 3 4

# 1 "/usr/include/machine/ieeefp.h" 1 3 4
# 5 "/usr/include/sys/config.h" 2 3 4
# 1 "/usr/include/sys/features.h" 1 3 4
# 6 "/usr/include/sys/config.h" 2 3 4
# 207 "/usr/include/sys/config.h" 3 4
# 1 "/usr/include/cygwin/config.h" 1 3 4
# 208 "/usr/include/sys/config.h" 2 3 4
# 17 "/usr/include/_ansi.h" 2 3 4
# 30 "/usr/include/stdio.h" 2 3 4

# 1 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 1 3 4
# 211 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 3 4
typedef unsigned int size_t;
# 35 "/usr/include/stdio.h" 2 3 4

# 1 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stdarg.h" 1 3 4
# 40 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stdarg.h" 3 4
typedef __builtin_va_list __gnuc_va_list;
# 38 "/usr/include/stdio.h" 2 3 4

# 1 "/usr/include/sys/reent.h" 1 3 4
# 13 "/usr/include/sys/reent.h" 3 4
# 1 "/usr/include/_ansi.h" 1 3 4
# 14 "/usr/include/sys/reent.h" 2 3 4
# 1 "/usr/include/sys/_types.h" 1 3 4
# 12 "/usr/include/sys/_types.h" 3 4
# 1 "/usr/include/machine/_types.h" 1 3 4

# 1 "/usr/include/machine/_default_types.h" 1 3 4
# 26 "/usr/include/machine/_default_types.h" 3 4
typedef signed char __int8_t ;
typedef unsigned char __uint8_t ;
# 36 "/usr/include/machine/_default_types.h" 3 4
typedef signed short __int16_t;
typedef unsigned short __uint16_t;
# 46 "/usr/include/machine/_default_types.h" 3 4
typedef __int16_t __int_least16_t;
typedef __uint16_t __uint_least16_t;
# 58 "/usr/include/machine/_default_types.h" 3 4
typedef signed int __int32_t;
typedef unsigned int __uint32_t;
# 76 "/usr/include/machine/_default_types.h" 3 4
typedef __int32_t __int_least32_t;
typedef __uint32_t __uint_least32_t;
# 99 "/usr/include/machine/_default_types.h" 3 4
typedef signed long long __int64_t;
typedef unsigned long long __uint64_t;
# 8 "/usr/include/machine/_types.h" 2 3 4
# 13 "/usr/include/sys/_types.h" 2 3 4
# 1 "/usr/include/sys/lock.h" 1 3 4
# 14 "/usr/include/sys/lock.h" 3 4
typedef void *_LOCK_T;
# 44 "/usr/include/sys/lock.h" 3 4
void __cygwin_lock_init(_LOCK_T *);
void __cygwin_lock_init_recursive(_LOCK_T *);
void __cygwin_lock_fini(_LOCK_T *);
void __cygwin_lock_lock(_LOCK_T *);
int __cygwin_lock_trylock(_LOCK_T *);
void __cygwin_lock_unlock(_LOCK_T *);
# 14 "/usr/include/sys/_types.h" 2 3 4

typedef long _off_t;

typedef short __dev_t;

typedef unsigned short __uid_t;

typedef unsigned short __gid_t;

__extension__ typedef long long _off64_t;

typedef long _fpos_t;

typedef _off64_t _fpos64_t;

typedef int _ssize_t;

# 1 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 1 3 4
# 352 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 3 4
typedef unsigned int wint_t;
# 64 "/usr/include/sys/_types.h" 2 3 4

typedef struct
{
  int __count;
  union
  {
    wint_t __wch;
    unsigned char __wchb[4];
  } __value;
} _mbstate_t;

typedef _LOCK_T _flock_t;

typedef void *_iconv_t;
# 15 "/usr/include/sys/reent.h" 2 3 4

typedef unsigned long __ULong;
# 37 "/usr/include/sys/reent.h" 3 4
struct _reent;

struct _Bigint
{
  struct _Bigint *_next;
  int _k, _maxwds, _sign, _wds;
  __ULong _x[1];
};

struct __tm
{
  int __tm_sec;
  int __tm_min;
  int __tm_hour;
  int __tm_mday;
  int __tm_mon;
  int __tm_year;
  int __tm_wday;
  int __tm_yday;
  int __tm_isdst;
};

struct _on_exit_args {
 void * _fnargs[32];
 void * _dso_handle[32];

 __ULong _fntypes;

 __ULong _is_cxa;
};
# 89 "/usr/include/sys/reent.h" 3 4
struct _atexit {
 struct _atexit *_next;
 int _ind;

 void (*_fns[32])(void);
        struct _on_exit_args _on_exit_args;
};
# 105 "/usr/include/sys/reent.h" 3 4
struct __sbuf {
 unsigned char *_base;
 int _size;
};
# 169 "/usr/include/sys/reent.h" 3 4
struct __sFILE {
  unsigned char *_p;
  int _r;
  int _w;
  short _flags;
  short _file;
  struct __sbuf _bf;
  int _lbfsize;

  void * _cookie;



  struct __sbuf _ub;
  unsigned char *_up;
  int _ur;

  unsigned char _ubuf[3];
  unsigned char _nbuf[1];

  struct __sbuf _lb;

  int _blksize;
  int _offset;

  struct _reent *_data;

  _flock_t _lock;

  _mbstate_t _mbstate;
  int _flags2;
};
# 226 "/usr/include/sys/reent.h" 3 4
struct __sFILE64 {
  unsigned char *_p;
  int _r;
  int _w;
  short _flags;
  short _file;
  struct __sbuf _bf;
  int _lbfsize;

  struct _reent *_data;

  void * _cookie;



  struct __sbuf _ub;
  unsigned char *_up;
  int _ur;

  unsigned char _ubuf[3];
  unsigned char _nbuf[1];

  struct __sbuf _lb;

  int _blksize;
  int _flags2;

  _off64_t _offset;


  _flock_t _lock;

  _mbstate_t _mbstate;
};
typedef struct __sFILE64 __FILE;

struct _glue
{
  struct _glue *_next;
  int _niobs;
  __FILE *_iobs;
};
# 305 "/usr/include/sys/reent.h" 3 4
struct _rand48 {
  unsigned short _seed[3];
  unsigned short _mult[3];
  unsigned short _add;

};
# 580 "/usr/include/sys/reent.h" 3 4
struct _reent
{
  int _errno;

  __FILE *_stdin, *_stdout, *_stderr;

  int _inc;
  char _emergency[25];

  int _current_category;
  const char *_current_locale;

  int __sdidinit;



  struct _Bigint *_result;
  int _result_k;
  struct _Bigint *_p5s;
  struct _Bigint **_freelist;

  int _cvtlen;
  char *_cvtbuf;

  union
    {
      struct
        {
          unsigned int _unused_rand;
          char * _strtok_last;
          char _asctime_buf[26];
          struct __tm _localtime_buf;
          int _gamma_signgam;
          __extension__ unsigned long long _rand_next;
          struct _rand48 _r48;
          _mbstate_t _mblen_state;
          _mbstate_t _mbtowc_state;
          _mbstate_t _wctomb_state;
          char _l64a_buf[8];
          char _signal_buf[24];
          int _getdate_err;
          _mbstate_t _mbrlen_state;
          _mbstate_t _mbrtowc_state;
          _mbstate_t _mbsrtowcs_state;
          _mbstate_t _wcrtomb_state;
          _mbstate_t _wcsrtombs_state;
   int _h_errno;
        } _reent;

      struct
        {

          unsigned char * _nextf[30];
          unsigned int _nmalloc[30];
        } _unused;
    } _new;

  struct _atexit *_atexit;
  struct _atexit _atexit0;

  void (**(_sig_func))(int);

  struct _glue __sglue;
  __FILE __sf[3];
};
# 818 "/usr/include/sys/reent.h" 3 4
extern struct _reent *_impure_ptr ;
extern struct _reent *const _global_impure_ptr ;

void _reclaim_reent (struct _reent *);


# 46 "/usr/include/stdio.h" 2 3 4
# 1 "/usr/include/sys/types.h" 1 3 4
# 69 "/usr/include/sys/types.h" 3 4
# 1 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 1 3 4
# 149 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 3 4
typedef int ptrdiff_t;
# 323 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stddef.h" 3 4
typedef short unsigned int wchar_t;
# 70 "/usr/include/sys/types.h" 2 3 4
# 1 "/usr/include/machine/types.h" 1 3 4
# 19 "/usr/include/machine/types.h" 3 4
typedef long int __off_t;
typedef int __pid_t;

__extension__ typedef long long int __loff_t;
# 71 "/usr/include/sys/types.h" 2 3 4
# 92 "/usr/include/sys/types.h" 3 4
typedef unsigned char u_char;
typedef unsigned short u_short;
typedef unsigned int u_int;
typedef unsigned long u_long;

typedef unsigned short ushort;
typedef unsigned int uint;
typedef unsigned long ulong;

typedef unsigned long clock_t;

typedef long time_t;

struct timespec {
  time_t tv_sec;
  long tv_nsec;
};

struct itimerspec {
  struct timespec it_interval;
  struct timespec it_value;
};

typedef long daddr_t;
typedef char * caddr_t;
# 172 "/usr/include/sys/types.h" 3 4
typedef int pid_t;
# 182 "/usr/include/sys/types.h" 3 4
typedef _ssize_t ssize_t;
# 201 "/usr/include/sys/types.h" 3 4
typedef unsigned short nlink_t;
# 223 "/usr/include/sys/types.h" 3 4
typedef long fd_mask;

typedef struct _types_fd_set {
 fd_mask fds_bits[(((64)+(((sizeof (fd_mask) * 8))-1))/((sizeof (fd_mask) * 8)))];
} _types_fd_set;
# 254 "/usr/include/sys/types.h" 3 4
typedef unsigned long clockid_t;

typedef unsigned long timer_t;

typedef unsigned long useconds_t;
typedef long suseconds_t;
# 452 "/usr/include/sys/types.h" 3 4
# 1 "/usr/include/cygwin/types.h" 1 3 4
# 20 "/usr/include/cygwin/types.h" 3 4
# 1 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stdint.h" 1 3 4

# 1 "/usr/include/stdint.h" 1 3 4
# 18 "/usr/include/stdint.h" 3 4
typedef signed char int8_t;
typedef short int16_t;
typedef int int32_t;
typedef long long int64_t;

typedef unsigned char uint8_t;
typedef unsigned short uint16_t;

typedef unsigned int uint32_t;

typedef unsigned long long uint64_t;

typedef signed char int_least8_t;
typedef short int_least16_t;
typedef int int_least32_t;
typedef long long int_least64_t;

typedef unsigned char uint_least8_t;
typedef unsigned short uint_least16_t;
typedef unsigned int uint_least32_t;
typedef unsigned long long uint_least64_t;

typedef signed char int_fast8_t;
typedef int int_fast16_t;
typedef int int_fast32_t;
typedef long long int_fast64_t;

typedef unsigned char uint_fast8_t;
typedef unsigned int uint_fast16_t;
typedef unsigned int uint_fast32_t;
typedef unsigned long long uint_fast64_t;

typedef int intptr_t;

typedef unsigned int uintptr_t;

typedef long long intmax_t;
typedef unsigned long long uintmax_t;
# 4 "/usr/lib/gcc/i686-pc-cygwin/4.5.3/include/stdint.h" 2 3 4
# 21 "/usr/include/cygwin/types.h" 2 3 4
# 1 "/usr/include/endian.h" 1 3 4
# 15 "/usr/include/endian.h" 3 4
# 1 "/usr/include/bits/endian.h" 1 3 4
# 16 "/usr/include/endian.h" 2 3 4
# 32 "/usr/include/endian.h" 3 4
# 1 "/usr/include/byteswap.h" 1 3 4
# 18 "/usr/include/byteswap.h" 3 4


typedef struct timespec timespec_t;

typedef struct timespec timestruc_t;

typedef _off64_t off_t;

typedef __loff_t loff_t;

typedef short __dev16_t;
typedef unsigned long __dev32_t;
typedef __dev32_t dev_t;

typedef long blksize_t;

typedef long __blkcnt32_t;
typedef long long __blkcnt64_t;
typedef __blkcnt64_t blkcnt_t;

typedef unsigned long fsblkcnt_t;

typedef unsigned long fsfilcnt_t;

typedef unsigned short __uid16_t;
typedef unsigned long __uid32_t;
typedef __uid32_t uid_t;

typedef unsigned short __gid16_t;
typedef unsigned long __gid32_t;
typedef __gid32_t gid_t;

typedef unsigned long __ino32_t;
typedef unsigned long long __ino64_t;
typedef __ino64_t ino_t;

typedef unsigned long id_t;
# 115 "/usr/include/cygwin/types.h" 3 4
struct flock {
 short l_type;
 short l_whence;
 off_t l_start;
 off_t l_len;
 pid_t l_pid;
};

typedef long long key_t;

typedef unsigned long vm_offset_t;

typedef unsigned long vm_size_t;

typedef void *vm_object_t;

typedef unsigned char u_int8_t;

typedef __uint16_t u_int16_t;

typedef __uint32_t u_int32_t;

typedef __uint64_t u_int64_t;

typedef __int32_t register_t;

typedef char *addr_t;

typedef unsigned mode_t;

typedef struct __pthread_t {char __dummy;} *pthread_t;
typedef struct __pthread_mutex_t {char __dummy;} *pthread_mutex_t;

typedef struct __pthread_key_t {char __dummy;} *pthread_key_t;
typedef struct __pthread_attr_t {char __dummy;} *pthread_attr_t;
typedef struct __pthread_mutexattr_t {char __dummy;} *pthread_mutexattr_t;
typedef struct __pthread_condattr_t {char __dummy;} *pthread_condattr_t;
typedef struct __pthread_cond_t {char __dummy;} *pthread_cond_t;

typedef struct
{
  pthread_mutex_t mutex;
  int state;
}
pthread_once_t;
typedef struct __pthread_spinlock_t {char __dummy;} *pthread_spinlock_t;
typedef struct __pthread_rwlock_t {char __dummy;} *pthread_rwlock_t;
typedef struct __pthread_rwlockattr_t {char __dummy;} *pthread_rwlockattr_t;
# 222 "/usr/include/cygwin/types.h" 3 4
# 1 "/usr/include/sys/sysmacros.h" 1 3 4
# 14 "/usr/include/sys/sysmacros.h" 3 4
# 1 "/usr/include/sys/types.h" 1 3 4
# 15 "/usr/include/sys/sysmacros.h" 2 3 4



typedef __FILE FILE;

typedef _fpos64_t fpos_t;

# 1 "/usr/include/sys/stdio.h" 1 3 4
# 14 "/usr/include/sys/stdio.h" 3 4
# 1 "/usr/include/sys/cdefs.h" 1 3 4
# 15 "/usr/include/sys/stdio.h" 2 3 4
# 35 "/usr/include/sys/stdio.h" 3 4


                              ;
# 552 "/usr/include/stdio.h" 3 4
typedef ssize_t cookie_read_function_t(void *__cookie, char *__buf, size_t __n);
typedef ssize_t cookie_write_function_t(void *__cookie, const char *__buf,
     size_t __n);

typedef int cookie_seek_function_t(void *__cookie, _off64_t *__off,
       int __whence);

typedef int cookie_close_function_t(void *__cookie);
typedef struct
{

  cookie_read_function_t *read;
  cookie_write_function_t *write;
  cookie_seek_function_t *seek;
  cookie_close_function_t *close;
} cookie_io_functions_t;
                                                         ;
# 595 "/usr/include/stdio.h" 3 4
extern __inline__ __attribute__ ((__always_inline__)) int __sgetc_r(struct _reent *__ptr, FILE *__p);

extern __inline__ __attribute__ ((__always_inline__)) int __sgetc_r(struct _reent *__ptr, FILE *__p)
  {
    int __c = (--(__p)->_r < 0 ? __srget_r(__ptr, __p) : (int)(*(__p)->_p++));
    if ((__p->_flags & 0x4000) && (__c == '\r'))
      {
      int __c2 = (--(__p)->_r < 0 ? __srget_r(__ptr, __p) : (int)(*(__p)->_p++));
      if (__c2 == '\n')
        __c = __c2;
      else
        ungetc(__c2, __p);
      }
    return __c;
  }
# 683 "/usr/include/stdio.h" 3 4

# 2 "quicksort.c" 2

int quicksort( int data[], int left, int right ){
    int pl, pr, pivot, tmp;
    pl = left; pr = right;
    pivot = data[ (pl+pr)/2 ];

    printf( "---\nquicksort( data, %d, %d )\n", left, right );
    while( pl <= pr ){
        while( data[pl] < pivot ){ pl++; }
        printf( " ** found data[%d]=%d >= %d\n", pl, data[pl], pivot );
        while( pivot < data[pr] ){ pr--; }
        printf( " ** found data[%d]=%d <= %d\n", pr, data[pr], pivot );

        if( pl <= pr ){
            printf( " swap: data[%d]=%d <=> data[%d]=%d\n",
                    pl, data[pl], pr, data[pr] );
            tmp = data[pl];
            data[pl] = data[pr];
            data[pr] = tmp;
            pl++;
            pr--;
        }
    }
    if( left < pr ){
        quicksort( data, left, pr );
    }
    if( pl < right ){
        quicksort( data, pl, right );
    }

    return 0;
}

int main(){
    int data[9] = { 5, 7, 1, 4, 6, 2, 3, 9, 8 };
    int i;

    printf( "== before ==\n" );
    for( i=0; i<9; i++ ){
        printf( "%d ", data[i] );
    }
    printf( "\n\n" );

    quicksort( data, 0, 8 );

    printf( "\n== after ==\n" );
    for( i=0; i<9; i++ ){
        printf( "%d ", data[i] );
    }
    printf( "\n" );

    return 0;
}
