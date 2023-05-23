<template>
  <div>
      请选择班级：
      <select  name="class" v-model="classNumSelected" @change="getvaluemethod1($event)">
        <!-- 通过v-for生成下拉框，每个下拉框的value和文本根据classNum决定 -->
        <option v-for="item in classNum" :value="item">{{ item }}</option>
      </select>
      请选择要批改哪一次作业：
      <select name="assignment" v-model="assignmentNumSelected" @change="getvaluemethod2($event)">
        <!-- 通过v-for生成下拉框，每个下拉框的value和文本根据assignmentNum决定 -->
        <option v-for="item in assignmentNum" :value="item">{{ item }}</option>
      </select>
      <!-- 点击查询之后在第一行下面应该会出现一系列数据，每一行数据包括 学号，姓名，选择某一个学号/姓名之后在右边会
        出现他的作业号等数据，点击某一行作业会跳转至批改界面 -->
      <button>查询</button>

      <!-- 
      测试classNumSelected有没有被正确的传递 
      {{ classNumSelected  }}
      测试正确，下拉框选中的值已经被正确的传递
      -->
      <!--测试assignmentNumSelected有没有被正确的传递
      {{ assignmentNumSelected }}
      测试正确，下拉框选中的值已经被正确的传递
      -->
      <!--这里是页面的下半实现-->
      <div>
        请选择要查看的学生:
        <!--使用一个下拉框来选择学号姓名进而批改作业-->
        <select name="student" v-model="studentSelected" @change="getvaluemethod3($event)">
          <!-- 通过v-for生成下拉框，每个下拉框的value和文本根据student决定 -->
          <option v-for="item in student" :value="item">{{ item }}</option>
        </select>

        <!-- 用v-for有序列表显示作业号，提交详情，代码，是否批改 -->
        <!-- 这里我实在是不知道怎么实现了，哭 -->
        <ol>
          <li v-for="item in assignmentNum">
            <!-- 这里是作业号 -->
            {{ item }}
            <!-- 这里是提交详情 -->
            <button>提交详情</button>
            <!-- 这里是代码 -->
            <button>代码</button>
            <!-- 这里是是否批改 -->
            <button>是否批改</button>
          </li>
        </ol>
      </div>

  </div>

</template>

<script>
    export default{
        data(){
            return{
              message:{},

              //TODO:后端传进来好几个课程号，现在假设是class1，class2，class3,具体是什么要取决于后端传过来的数值
              classNum:["class1","class2","class3"],
              //TODO:这个变量是老师实际要查询的课程号，留出接口供数据库使用
              classNumSelected:"",

              //TODO:后端传进来好几个作业号，现在假设是assignment1，assignment2，assignment3,具体是什么要取决于后端传过来的数值
              assignmentNum:["assignment1","assignment2","assignment3"],
              //TODO:这个变量是老师实际要查询的作业号，留出接口供数据库使用
              assignmentNumSelected:"",

              //TODO:后端传进来好几个学生，现在假设是student1，student2，student3,具体是什么要取决于后端传过来的数值
              student:["student1","student2","student3"],
              //TODO:这个变量是老师实际要查询的学生，留出接口供数据库使用
              studentSelected:"",
            }
        },
        methods:{
          //获取下拉框选中的值并赋值给classNUmSelected
          getvaluemethod1: function(event) {
              _this.classNumSelected = event.target.value;
          },
          //获取下拉框选中的值并赋值给assignmentNumSelected
          getvaluemethod2:function(event){
              _this.assignmentNumSelected = event.target.value;
          },
          //获取下拉框选中的值并赋值给studentSelected
          getvaluemethod3:function(event){
              _this.studentSelected = event.target.value;
          }
        }
    } 
</script>

<style scoped>
/*这里是想将*/

</style>
