﻿
namespace PkcsExtensionsBlazor {

    // For Browser support see https://diafygi.github.io/webcrypto-examples/

    /**
     * Convert Uint8Array to Base64 string.
     * @param uint8Array
     */
    function toBase64(uint8Array: Uint8Array): string {
        return window.btoa(uint8Array.reduce((data, byte) => data + String.fromCharCode(byte), ''));
    }

    /**
     * Generate random bytes with size as Base64 string.
     * @param size The size of random bytes.
     * @returns Random bytes as Base64 string.
     */
    const getRandomValues = function (size: number): string {
        let array = new Uint8Array(size);
        crypto.getRandomValues(array);
        return toBase64(array);
    };

    const generateKeyRsa = function (modulusLength: number, name = 'RSA-OAEP'): PromiseLike<string> {
        return crypto.subtle.generateKey({
            name: name,
            modulusLength: modulusLength,
            publicExponent: new Uint8Array([0x01, 0x00, 0x01]),
            hash: { name: 'SHA-256' },
        }, true, ['encrypt', 'decrypt'])
            .then(t => crypto.subtle.exportKey('pkcs8', t.privateKey))
            .then(buffer => toBase64(new Uint8Array(buffer)));
    };

    export function Load(): void {
        window['PkcsExtensionsBlazor_getRandomValues'] = getRandomValues;
        window['PkcsExtensionsBlazor_generateKeyRsa'] = generateKeyRsa;
    }
}

PkcsExtensionsBlazor.Load();