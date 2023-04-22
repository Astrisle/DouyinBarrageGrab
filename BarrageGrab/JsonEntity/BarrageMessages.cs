using Newtonsoft.Json;
using System;

namespace BarrageGrab.JsonEntity
{
    /// <summary>
    /// 弹幕消息类型
    /// </summary>
    public enum BarrageMsgType
    {
        无 = 0,
        弹幕消息 = 1,
        点赞消息 = 2,
        进房提醒 = 3,
        关注消息 = 4,
        礼物消息 = 5,
        直播间统计 = 6,
        粉丝团消息 = 7,
        直播间分享 = 8,
        下播 = 9
    }

    /// <summary>
    /// 粉丝团消息类型
    /// </summary>
    public enum FansclubType
    {
        无 = 0,
        粉丝团升级 = 1,
        加入粉丝团 = 2
    }

    /// <summary>
    /// 直播间分享目标
    /// </summary>
    public enum ShareType
    {
        未知 = 0,
        微信 = 1,
        朋友圈 = 2,
        微博 = 3,
        QQ空间 = 4,
        QQ = 5,
        抖音好友 = 112
    }


    /// <summary>
    /// 数据包装器
    /// </summary>
    public class BarrageMsgPack
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public BarrageMsgType Type { get; set; }

        /// <summary>
        /// 消息对象
        /// </summary>
        public string Data { get; set; }

        public BarrageMsgPack()
        {

        }

        public BarrageMsgPack(string data, BarrageMsgType type)
        {
            this.Data = data;
            this.Type = type;
        }
    }

    /// <summary>
    /// 消息
    /// </summary>
    public class Msg
    {
        /// <summary>
        /// 弹幕ID
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 用户数据
        /// </summary>
        public MsgUser User { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public long RoomId { get; set; }
    }

    /// <summary>
    /// 粉丝团信息
    /// </summary>
    public class FansClubInfo
    {
        /// <summary>
        /// 粉丝团名称
        /// </summary>
        public string ClubName { get; set; }

        /// <summary>
        /// 粉丝团等级，没加入则0
        /// </summary>
        public int Level { get; set; }
    }

    /// <summary>
    /// 用户弹幕信息
    /// </summary>
    public class MsgUser
    {
        /// <summary>
        /// 真实ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 自定义ID
        /// </summary>
        public string DisplayId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 性别 1男 2女
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 用户主页地址
        /// </summary>
        public string SecUid { get; set; }

        /// <summary>
        /// 粉丝团信息
        /// </summary>
        public FansClubInfo FansClub { get; set; }

        public string GenderToString()
        {
            return Gender == 1 ? "男" : Gender == 2 ? "女" : "未知";
        }
    }

    /// <summary>
    /// 礼物消息
    /// </summary>
    public class GiftMsg : Msg
    {
        /// <summary>
        /// 礼物ID
        /// </summary>
        public long GiftId { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public MsgUser To { get; set; }

        /// <summary>
        /// 礼物名称
        /// </summary>
        public string GiftName { get; set; }

        /// <summary>
        /// 本次(增量)礼物数量
        /// </summary>
        public long GiftCount { get; set; }

        /// <summary>
        /// 礼物数量(连续的)
        /// </summary>
        public long RepeatCount { get; set; }

        /// <summary>
        /// 抖币价格
        /// </summary>
        public int DiamondCount { get; set; }
    }

    /// <summary>
    /// 点赞消息
    /// </summary>
    public class LikeMsg : Msg
    {
        /// <summary>
        /// 点赞数量
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// 总共点赞数量
        /// </summary>
        public long Total { get; set; }
    }

    /// <summary>
    /// 直播间统计消息
    /// </summary>
    public class UserSeqMsg : Msg
    {
        /// <summary>
        /// 当前直播间用户数量
        /// </summary>
        public long OnlineUserCount { get; set; }

        /// <summary>
        /// 累计直播间用户数量
        /// </summary>
        public long TotalUserCount { get; set; }

        /// <summary>
        /// 累计直播间用户数量 显示文本
        /// </summary>
        public string TotalUserCountStr { get; set; }

        /// <summary>
        /// 当前直播间用户数量 显示文本
        /// </summary>
        public string OnlineUserCountStr { get; set; }
    }

    /// <summary>
    /// 粉丝团消息
    /// </summary>
    public class FansclubMsg : Msg
    {
        /// <summary>
        /// 粉丝团消息类型,升级1，加入2
        /// </summary>
        public int Type { get; set; }
    }

    /// <summary>
    /// 来了消息
    /// </summary>
    public class MemberMessage : Msg
    {
        /// <summary>
        /// 当前直播间人数
        /// </summary>
        public long CurrentCount { get; set; }
    }

    /// <summary>
    /// 直播间分享
    /// </summary>
    public class ShareMessage : Msg
    {
        /// <summary>
        /// 分享目标
        /// </summary>
        public ShareType ShareType { get; set; }
    }

    /// <summary>
    /// 斗鱼STT弹幕协议显示基准
    /// </summary>
    public class STTBaseTemplate
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 唯一Key
        /// </summary>
        [JsonProperty("key")]
        public long Key { get; set; }

        /// <summary>
        /// Date String
        /// </summary>
        [JsonProperty("dt")]
        public string SendTime { get; set; } = DateTime.Now.ToString("HH:mm:ss");
    }

    /// <summary>
    /// STT礼物JSON结构
    /// </summary>
    public class STTGift : STTBaseTemplate
    {
        /// <summary>
        /// 送礼用户名
        /// </summary>
        [JsonProperty("nn")]
        public string UserName { get; set; }
        /// <summary>
        /// 礼物ID
        /// </summary>
        [JsonProperty("gfid")]
        public long GiftId { get; set; }
        /// <summary>
        /// 礼物名 - 新增
        /// </summary>
        [JsonProperty("gfname")]
        public string GiftName { get; set; }
        /// <summary>
        /// 礼物数量 - TODO: 区分批量/单体
        /// </summary>
        [JsonProperty("gfcnt")]
        public int Count { get; set; }
        /// <summary>
        /// 连击数
        /// </summary>
        [JsonProperty("hits")]
        public int Hits { get; set; }
        /// <summary>
        /// 礼物价格
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }
        /// <summary>
        /// 接收人
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

    }

    /// <summary>
    /// STT弹幕消息JSON结构
    /// </summary>
    public class STTChatMessage : STTBaseTemplate
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("nn")]
        public string UserName { get; set; }
        /// <summary>
        /// 弹幕内容
        /// </summary>
        [JsonProperty("txt")]
        public string Message { get; set; }
    }

    /// <summary>
    /// STT进房提醒JSON结构
    /// </summary>
    public class STTUserEnter : STTBaseTemplate
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("nn")]
        public string UserName { get; set; }
    }

    public class STTRoomStats : STTBaseTemplate
    {

    }
}