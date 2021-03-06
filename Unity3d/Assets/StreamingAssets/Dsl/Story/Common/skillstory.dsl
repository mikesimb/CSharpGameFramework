story(skill_main)
{
  local
  {
    @killObjId(0);
    @anniId(0);
    @anniTargetId(0);
    @bearId(0);
    @anniPos(0); 
    @anniDir(0);
    @hanbingId(0);
    @hanbingArrowId(0);
    @hanbingPos(0);
    @hanbingDir(0);
    @ezId(0);
    @ezArrowId(0);
    @ezPos(0);
    @ezDir(0);
  };
  onmessage("kill_summon_npc")
  {
    @killObjId=$0.ActorId;
    destroynpcwithobjid(@killObjId);
  };
  onmessage("kill_npc")
  {
    log("kill_npc");
    sethp(unitid2objid($1),0);
  };
  onmessage("summon_bear")
  {
    @anniId=$0.ActorId;
    @anniTargetId=$0.TargetActorId;
    if(@anniTargetId<=0){
      @anniTargetId = @anniId;
      @anniPos = calcoffset(@anniTargetId,0,vector3(0,0,2));
      @anniDir=calcdir(@anniId,0);
    }else{
      @anniPos = calcoffset(@anniTargetId,@anniId,vector3(0,0,-1));
      @anniDir=calcdir(@anniTargetId,@anniId);
    };
    log("summon_bear:{0} {1} {2}",@anniId,@anniPos,@anniDir);
    createnpc(0,@anniPos,@anniDir,getcamp(@anniId),str2int($1),str2int($2),stringlist(""))objid("@bearId");
    objsetsummonerid(@bearId,@anniId);
    objsetformation(@bearId,5);
    objsetaitarget(@bearId,@anniTargetId);
    objaddimpact(@bearId,12);
  };
  onmessage("summon_hanbing_arrow")
  {
    @hanbingId=$0.ActorId;
    @hanbingPos=getposition(@hanbingId);
    @hanbingDir=calcdir(@hanbingId,0);
    log("summon_hanbing_arrow:{0} {1} {2}",@hanbingId,@hanbingPos,@hanbingDir);
    createnpc(0,@hanbingPos,@hanbingDir,getcamp(@hanbingId),str2int($1),str2int($2),stringlist(""))objid("@hanbingArrowId");
    objsetsummonerid(@hanbingArrowId,@hanbingId);
  };
  onmessage("ez_skill_r")
  {
    @ezId=$0.ActorId;
    @ezPos=getposition(@ezId);
    @ezDir=calcdir(@ezId,0);
    log("ez_skill_r:{0} {1} {2}",@ezId,@ezPos,@ezDir);
    createnpc(0,@ezPos,@ezDir,getcamp(@ezId),33,1,stringlist("ez_r_arrow Ai/ailogic_ez_r_arrow.dsl"))objid("@ezArrowId");
    objsetsummonerid(@ezArrowId,@ezId);
    objcastskill(@ezArrowId,20);
  };
};