# Suoja
File Encryption Tool made for the IT-Talents Code Competition 04/2016

### Important Notice
This repository is not made for reproduction as the directory structure is adjusted!

### Features
* Encrypt any file using strong Rijndael-256 algorithm.
* Decrypt files with the corresponding key data at any time.
* Encrypted files are signed using HMAC and SHA256 as hash-algorithm.
* Drag & Drop files into the form to get more en-/decryption options. (See table down below for more details.)
* Encode filenames to prevent conclusion to the original file.
* Quick-Add jobs by right-clicking a file > Open With.

### Multiple-File-Handling Options
When Drag & Drop multiple files into the form, there are several options to choose from on how to handle the files.

|Option|Behaviour|
|---|---|
|`Compression (Encryption only)`|Compresses all files in an encrypted archive.|
|`Individual (Standard)`|Allows to select all options for each file itself.|
|`Equal`|Allows to select all options once (like a template) which will then get applied to all files.|

### Filename Encoding
There are two options to choose from on how to handle the filename.

|Option|Behaviour|
|---|---|
|`Keep (Standard)`|The filename stays the same and Suoja only adds an `.suoja` to it. Makes it easier to remember which file is which.|
|`Encode (Recommended)`|The filename is being encoded and then Suoja adds the `.suoja`. Makes it harder to remember which file is which but will increase safety as it prevents conclusion to the orignial filename. When importing a file with an encoded name Suoja will automatically display it's original name.|

### License and Redistributation Details
Suoja and all it's components are licensed according to the [Creative Commons CC BY-NC-SA 4.0 License](http://creativecommons.org/licenses/by-nc-sa/4.0/).

### Disclaimer
```
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
```
