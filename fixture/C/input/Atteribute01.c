typedef unsigned int size_t;

int __attribute__((__cdecl__)) getchar (void);
char * __attribute__((__cdecl__)) gets (char *);

long __attribute__((__cdecl__)) ftell ( FILE *);
void __attribute__((__cdecl__)) rewind (FILE *);
void __attribute__((__cdecl__)) clearerr (FILE *);


FILE * __attribute__((__cdecl__)) fopen (const char *_name, const char *_type);

off_t __attribute__((__cdecl__)) ftello ( FILE *);
