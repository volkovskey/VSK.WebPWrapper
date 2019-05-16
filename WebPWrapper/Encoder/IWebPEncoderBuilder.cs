﻿using System;
using System.Linq.Expressions;

namespace WebPWrapper.Encoder {
    public interface IWebPEncoderBuilder {
        /// <summary>
        /// 輸入圖片裁減
        /// </summary>
        /// <param name="x">起始座標X</param>
        /// <param name="y">起始座標Y</param>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param> 
        WebPEncoderBuilder Crop(uint x, uint y, uint width, uint height);

        /// <summary>
        /// 縮放圖片，<paramref name="height"/>與<paramref name="width"/>至少一者非0，如果其中一值為0則等比例縮放
        /// </summary>
        /// <param name="width">寬度</param>
        /// <param name="height">寬度</param> 
        WebPEncoderBuilder Resize(uint width, uint height);

        /// <summary>
        /// 容許多執行序
        /// </summary>
        WebPEncoderBuilder MultiThread();

        /// <summary>
        /// 降低記憶體使用
        /// </summary>
        WebPEncoderBuilder LowMemory();

        /// <summary>
        /// 複製來源圖片的Metadata
        /// </summary>
        WebPEncoderBuilder CopyMetadata(params Metadatas[] metadatas);

        /// <summary>
        /// 停用ASM優化
        /// </summary>
        WebPEncoderBuilder DisableAssemblyOptimization();

        /// <summary>
        /// 讀取預設的組態
        /// </summary>
        /// <param name="profile">組態類型</param> 
        WebPEncoderBuilder LoadPresetProfile(PresetProfiles profile);

        /// <summary>
        /// 設定壓縮組態
        /// </summary>
        /// <param name="config">壓縮組態設定</param> 
        WebPEncoderBuilder CompressionConfig(Expression<Action<CompressionConfiguration>> config);

        /// <summary>
        /// 設定Alpha組態
        /// </summary>
        /// <param name="config">Alpha組態設定</param>
        WebPEncoderBuilder AlphaConfig(Expression<Action<AlphaConfiguration>> config);

        /// <summary>
        /// 重設回預設值
        /// </summary>
        WebPEncoderBuilder Reset();

        /// <summary>
        /// 建構WebP編碼器
        /// </summary>
        /// <returns>WebP編碼器</returns>
        IWebPEncoder Build();
    }
}