namespace Tools.Monster
{
    //元素
    public enum Element
    {
        火,
        水,
        风,
        地
        
    }
    //程度等级
    public enum DetermineExtent
    {
        S,
        A,
        B,
        C,
        D
    }
    //技能效果
    public enum SkillEffect
    {
        伤害,
        增益,
        回复,
        
    }

    public enum MonsterRealTimeField
    {
        不可视,
    }
    //怪物补正属性
    public enum MonsterStateV
    {
        物理攻击,
        物理防御,
        特殊攻击,
        特殊防御,
        生命值,
        耐力值,
        负重值,
        当前生命,
        当前耐力

    }
    /// <summary>
    /// 阵营
    /// </summary>
    public enum Camp
    {
        己方,
        友军,
        中立,
        敌方,
    }public enum SkillTarget
    {
        己方,
        友军,
        中立,
        敌方,
        建筑,
        地形,
    }

    public enum ItemType
    { 
        装备,
        消耗品,
        产物,
        素材
        
        
    }
    
}