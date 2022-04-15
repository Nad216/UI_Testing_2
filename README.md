Add below tag before git commit message

ex: [FIX] - Update payment validation

[FIX] for bug fixes: mostly used in stable version but also valid if you are fixing a recent bug in development version;

[REF] for refactoring: when a feature is heavily rewritten;

[ADD] for adding new modules;

[REM] for removing resources: removing dead code, removing views, removing modules, …;

[REV] for reverting commits: if a commit causes issues or is not wanted reverting it is done using this tag;

[MOV] for moving files: use git move and do not change content of moved file otherwise Git may loose track and history of the file; also used when moving code from one file to another;

[REL] for release commits: new major or minor stable versions;

[IMP] for improvements: most of the changes done in development version are incremental improvements not related to another tag;

[MERGE] for merge commits: used in forward port of bug fixes but also as main commit for feature involving several separated commits;

[CLA] for signing the Odoo Individual Contributor License;

[I18N] for changes in translation files;
