<template>
    <!--本页面为学生点击查看老师评语按钮后的页面-->
    <div class="studentCorrectList">
  
        <h1>欢迎！{{ username }}</h1>
      
        <h2>请查看您的作业提交情况!</h2>

        <el-table :data="Assignment" border height="400" style="width: 100%" >
        <el-table-column prop="num" label="作业号" width="180" />
        <el-table-column prop="state" label="批改状态" width="180" />

      <!--下面这一行的代码应该实现成点击就可以跳转至批改界面的功能，暂时还没做-->
        <el-table-column prop="url" label="查看批改情况" />
    </el-table>
    <!--返回按钮-->
    <el-button type="info">返回上一页</el-button>
    </div>

</template>
      
<script>
export default{

    name:"StudentCorrectListPage",
    data(){

        return{
            //TODO: 后端传进来username作为欢迎语
            username: "张三",
            //TODO: 后端传进来的作业号和批改状态,true表示已批改，false表示未批改，
            //TODO: 还要实现一个功能是点击查看批改情况之后跳转到批改界面，然后可以查看老师的批改情况（针对每一行代码），这里我不太明白怎么实现，交给你了
            Assignment:[
                {num:"001", state:true, url:"/view/StudentPage/StudentPage3"},
                {num:"002", state:false, url:"/view/StudentPage/StudentPage3"},
            ],
  
        }
    },
    methods:{
                    
    }
} 
</script>
      
<style lang="scss" scoped>
    .studentCorrectList{
        text-align:center;
        position:absolute;
        width: 100%;
        height: 100%;
        background-image: url('/images/svgs/login-bg.svg');
    }
    h1,h2{
        color:#f9cdaa;
    }
    .el-button{
        float:right;
    }
</style>
      