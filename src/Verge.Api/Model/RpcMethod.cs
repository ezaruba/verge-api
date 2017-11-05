﻿namespace Verge.Api.Model
{
    public enum RpcMethod
    {
        addMultiSigAddress
      , backupWallet
      , createRawTransaction
      , decodeRawTransaction
      , dumpPrivKey
      , encryptWallet
      , getAccount
      , getAccountAddress
      , getAddressesByAccount
      , getBalance
      , getBlock
      , getBlockCount
      , getBlockHash
      , getConnectionCount
      , getDifficulty
      , getGenerate
      , getHashesPerSec
      , getInfo
      , getMemoryPool
      , getMiningInfo
      , getNewAddress
      , getRawTransaction
      , getReceivedByAccount
      , getReceivedByAddress
      , getTransaction
      , getWork
      , help
      , importPrivKey
      , importAddress
      , keyPoolRefill
      , listAccounts
      , listReceivedByAccount
      , listReceivedByAddress
      , listSinceBlock
      , listTransactions
      , listUnspent
      , move
      , sendFrom
      , sendMany
      , sendRawTransaction
      , sendToAddress
      , setAccount
      , setGenerate
      , setTxFee
      , signMessage
      , signRawTransaction
      , stop
      , validateAddress
      , verifyMessage
      , walletLock
      , walletPassphrase
      , walletPassphraseChange
    }
}
