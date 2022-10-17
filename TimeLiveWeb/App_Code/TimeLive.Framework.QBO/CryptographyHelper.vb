Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Security.Cryptography
Public Class CryptographyHelper
    Private Sub New()
    End Sub
    ''' <summary>
    ''' Encrypt using triple DES
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Friend Shared Function EncryptData(plaintext As String, key As String) As String
        Dim TripleDes As New TripleDESCryptoServiceProvider()
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream()
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray())
    End Function

    ''' <summary>
    ''' Decrypt using triple DES
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Friend Shared Function DecryptData(encryptedtext As String, key As String) As String

        Dim TripleDes As New TripleDESCryptoServiceProvider()
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream()
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray())
    End Function



    ''' <summary>
    '''  truncate or pad the hash based on required length 
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    Private Shared Function TruncateHash(key As String, length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider()

        ' Hash the key.
        Dim keyBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash As Byte() = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        Array.Resize(hash, length)
        Return hash
    End Function



End Class
