﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PkcsExtenions
{
    public static class HashAlgorithmConvertor
    {
        public static string ToOid(HashAlgorithmName hashAlgorithmName)
        {
            if (HashAlgorithmName.SHA256.Equals(hashAlgorithmName))
            {
                return Oids.SHA256;
            }

            if (HashAlgorithmName.SHA384.Equals(hashAlgorithmName))
            {
                return Oids.SHA384;
            }

            if (HashAlgorithmName.SHA512.Equals(hashAlgorithmName))
            {
                return Oids.SHA512;
            }

            if (HashAlgorithmName.SHA1.Equals(hashAlgorithmName))
            {
                return Oids.SHA1;
            }

            if (HashAlgorithmName.MD5.Equals(hashAlgorithmName))
            {
                return Oids.MD5;
            }

            throw new NotSupportedException($"Not support algorithm {hashAlgorithmName.Name} in HashAlgorithmConvertor method.");
        }
    }
}
