<template>
  <!--本页面是教师点击发布作业按钮之后跳转到的页面-->
  <div class="teacherRealease">
    <br>
    <div id="div1">请您发布作业！</div>
    <br><br><br>
    <div class="allSelect">
      请选择班级 
      <el-select v-model="label" placeholder="please select your class" @change="SelectClass">
        <el-option v-for="(course,index) in classInfo" :label="course.courseName" :value="course.id" :key="course.id"/>
      </el-select>
    </div>
     
    <br><br>
    <div class="allSelect">
      <div>作业标题/简介：</div>
      <el-input type="textarea" size="large" style="width: 50vw"
        rows="5" v-model="task_desc" placeholder="请输入内容  " />
    </div>

    <br><br><br>
    <!--截止日期控件，但是功能没做好，不知道选择的日期传递到哪里去-->
    <div class="allSelect">
      <span class="demonstration">请设置截止日期：</span>
      <el-date-picker
        v-model="date"
        type="datetime"
        placeholder="请选择截止时间"
        :shortcuts="shortcuts"
      />
    </div>
  
    <br><br><br>

    
    <br><br><br>
    <!--点击发布作业之后会跳转到作业列表页面,功能未实现-->
    <router-link to="/TeacherRealeasePage">
      <el-button class="publish" type="success" @click="submit" round>点击发布作业</el-button>
    </router-link>
    <!--返回按钮-->
    <el-button class="back" type="info">返回上一页</el-button>
  </div>
</template>
  
<script>
import { normalizeStyle } from 'vue';
import axios from '../../api/config'
import { ElMessage, ElMessageBox } from 'element-plus'
  export default{

    name:"TaecherRealeasePage",
    data(){
      return{
        //TODO:发布作业的班级号，如果有时间的话可以完善，后端向classNum传输数据
        
        //TODO:老师选中要发布的班级号，classNumPolished为向后端传输的数据
        now_classID:-1,
    
        //TODO:发布作业的标题/简介
        task_desc:"",
        classInfo: null,
        date:null,
        label:null
      }
    },
    
    created(){
      axios.get('api/TeacherWork/getClass?id=' + this.$cookies.get("userInfo").userId).then(
              response => {
                  this.classInfo = response.data;
                  console.log(this.classInfo);
              }
          )
    },
    methods:{
      SelectClass(value) {
        this.$forceUpdate();
        this.now_classID = value;                
        console.log(this.label)
      },
      submit(){
        axios({
          method: 'POST',
          url: 'api/release',
          params: {
            courseId:this.label,
            desc:this.task_desc,
            startTime:new Date(),
            endTime:this.date
          }
        })
        .then(response => {
            console.log(response.data)
            if(response.data == 1){
              ElMessage({
                type: 'success',
                message: '发布成功',
            })
            }else{
              ElMessage({
                type: 'error',
                message: '未知的错误，请联系管理员',
            })
            }
        }, error => {
            ElMessage({
                type: 'error',
                message: '未知的错误，请联系管理员',
            })
        })
      }
    }
  }
</script>

<style lang="scss" scoped>
  .teacherRealease{
    width: 95vw;
    height: 95vh;
    color:#f9cdaa;
    background-image: url('../../public/images/svgs/login-bg.svg');
    
    .back{
      float:right;
    }
  #div1{
    font-size:25px;
    height: 30px;
    text-align: center;
  }
  #div2{
    height:80px;
  }
  .allSelect{
    font-size:20px;
  }
}
</style>